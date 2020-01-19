import { Injectable } from '@angular/core';
import { Note } from './note.model';
import { Subject } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class NoteService {

	// tslint:disable-next-line:variable-name
	private $_currentNote: Subject<Note>;
	get $currentNote(): Subject<Note> {
		return this.$_currentNote;
	}
	private note: Note;

	constructor(private noteService: NoteService) {
		this.$_currentNote = new Subject<Note>();
	}

	public updateCurrent(note: Note): void {
		this.note = note;
		this.$_currentNote.next(this.note);
	}

		public saveCurrent(): boolean {

		}
}
