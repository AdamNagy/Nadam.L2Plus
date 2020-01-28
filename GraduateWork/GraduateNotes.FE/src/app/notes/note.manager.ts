import { Injectable } from '@angular/core';
import { Note, NoteType } from './note.model';
import { BehaviorSubject } from 'rxjs';
import { NoteService } from './note.service';
import { AccountManager } from '../account/account.manager';

@Injectable({
	providedIn: 'root'
})
export class NoteManager {

	// opeend note for editing
	private openedNote: Note;
	private _$openedNote: BehaviorSubject<Note>;
	get $openedNote(): BehaviorSubject<Note> {
		return this._$openedNote;
	}

	// my-notes
	private notes: Note[] = [];
	private _$notes: BehaviorSubject<Note[]>;
    get $notes(): BehaviorSubject<Note[]> {
        return this._$notes;
    }

	// save success
	private saveSuccess: boolean;
	private _$saveSuccess: BehaviorSubject<boolean>;
	get $saveSuccess(): BehaviorSubject<boolean> {
		return this._$saveSuccess;
	}

	constructor(
		private noteService: NoteService,
		private accountManager: AccountManager
	) {
		this.openedNote = {
			content: '',
			noteid: -1,
			created: new Date(),
			type: NoteType.text
		};

		this._$openedNote = new BehaviorSubject<Note>(this.openedNote);
		this._$notes = new BehaviorSubject<Note[]>([]);
		this._$saveSuccess = new BehaviorSubject<boolean>(false);
	}

	public updateLocal(note: Note): void {
		this.openedNote = note;
		this._$openedNote.next(this.openedNote);
	}

	public saveCurrent(): void {

		if ( this.openedNote.noteid === undefined) {
			this.noteService
				.post(this.openedNote, this.accountManager.account.token)
				.subscribe(newNote => {
					this.notes.push(newNote);
					this.updateLocal(newNote);

					this._$saveSuccess.next(true);
					this.$notes.next(this.notes);
				});
		} else {
			this.noteService
				.patch(this.openedNote, this.accountManager.account.token)
				.subscribe(newNote => {
					this.updateLocal(newNote);
					this._$saveSuccess.next(true);
				});
		}
	}

	public getNotes(): void {
		this.noteService.get(this.accountManager.account.token)
			.subscribe(notes => {
				this.notes = notes;
				this._$notes.next(this.notes);
			});
	}

	public getNoteById(id: number): Note {
		const note = this.notes.find(item => item.noteid === id);
		// tslint:disable-next-line: no-string-literal
		return note;
	}

	public delete(id: number) {
		this.noteService.delete(id, this.accountManager.account.token)
			.subscribe(() => {
				const noteToDelete = this.getNoteById(id);
				this.notes.splice(this.notes.indexOf(noteToDelete), 1);
				this._$notes.next(this.notes);
			});
	}

	public reset() {
		this.notes = [];
		this.$notes.next([]);

		this.openedNote = undefined;
		this.$openedNote.next(undefined);
	}

	public shareNote(partnerEmail: string, noteId: number) {
		this.noteService.shareNoteWith({partnerid: partnerEmail, noteid: noteId}, this.accountManager.account.token)
			.subscribe(item => {
				this._$saveSuccess.next(true);
			});
	}
}
