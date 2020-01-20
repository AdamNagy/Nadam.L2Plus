import { Injectable } from '@angular/core';
import { Note } from './note.model';
import { Subject } from 'rxjs';
import { NoteService } from './note.service';
import { AccountService } from '../account/account.service';

@Injectable({
	providedIn: 'root'
})
export class NoteManager {

	private _$currentNote: Subject<Note>;
	get $currentNote(): Subject<Note> {
		return this._$currentNote;
	}
	private currentNote: Note;

	constructor(
		private noteService: NoteService,
		private accountService: AccountService) {
			this._$currentNote = new Subject<Note>();
	}

	public updateLocal(note: Note): void {
		this.currentNote = note;
		this._$currentNote.next(this.currentNote);
	}

	public saveCurrent(): void {
		this.noteService
			.post(this.currentNote, this.accountService.token)
			.subscribe(newNote => {
				this.updateLocal(newNote);
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
