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

	// multiple selected notes for bulk operation
	private selectedNotes: Note[];
	private _$selectedNotes: BehaviorSubject<Note[]>;
    get $selectedNotes(): BehaviorSubject<Note[]> {
        return this._$selectedNotes;
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
		this._$selectedNotes = new BehaviorSubject<Note[]>([]);
	}

	public updateLocal(note: Note): void {
		this.openedNote = note;
		this._$openedNote.next(this.openedNote);
	}

	public saveCurrent(): void {

		if ( this.openedNote.noteid === undefined) {
			this.noteService
				.post(this.openedNote, this.accountManager.token)
				.subscribe(newNote => {
					this.updateLocal(newNote);
				});
		} else {
			this.noteService
				.patch(this.openedNote, this.accountManager.token)
				.subscribe(newNote => {
					this.updateLocal(newNote);
				});
		}
	}

	public getNotes(): void {
		this.noteService.get(this.accountManager.token)
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

	// public updateCurrent(): void {
	// 	this.noteService
	// 		.patch(this.currentNote, this.accountService.token)
	// 		.subscribe(newNote => {
	// 			this.updateLocal(newNote);
	// 		});
	// }
}
