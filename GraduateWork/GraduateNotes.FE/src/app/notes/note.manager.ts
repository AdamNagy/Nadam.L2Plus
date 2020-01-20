import { Injectable } from '@angular/core';
import { Note, NoteType } from './note.model';
import { Subject, BehaviorSubject } from 'rxjs';
import { NoteService } from './note.service';
import { AccountService } from '../account/account.service';

@Injectable({
	providedIn: 'root'
})
export class NoteManager {

	private currentNote: Note;
	private _$currentNote: BehaviorSubject<Note>;
	get $currentNote(): BehaviorSubject<Note> {
		return this._$currentNote;
	}

	constructor(
		private noteService: NoteService,
		private accountService: AccountService) {
			this.currentNote = {
				Content: '',
				Id: -1,
				Created: new Date(),
				Type: NoteType.text
			};
			this._$currentNote = new BehaviorSubject<Note>(this.currentNote);
	}

	public updateLocal(note: Note): void {
		this.currentNote = note;
		this._$currentNote.next(this.currentNote);
	}

	public saveCurrent(): void {

		this.accountService.$token.subscribe(token => {
			if ( this.currentNote.Id === undefined ) {
				this.noteService
					.post(this.currentNote, token)
					.subscribe(newNote => {
						this.updateLocal(newNote);
					});
			} else {
				this.noteService
					.patch(this.currentNote, token)
					.subscribe(newNote => {
						this.updateLocal(newNote);
					});
			}
		});
	}

	// public updateCurrent(): void {
	// 	this.noteService
	// 		.patch(this.currentNote, this.accountService.token)
	// 		.subscribe(newNote => {
	// 			this.updateLocal(newNote);
	// 		});
	// }
}
