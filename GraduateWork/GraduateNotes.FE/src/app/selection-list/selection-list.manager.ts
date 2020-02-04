import { BehaviorSubject } from 'rxjs';
import { Note } from '../notes/note.model';
import { Injectable } from '@angular/core';

@Injectable({
	providedIn: 'root'
})
export class SelectionListManager {

	// multiple selected notes for bulk operation
	private selectedNotes: number[];
	private _$selectedNotes: BehaviorSubject<number[]>;
    get $selectedNotes(): BehaviorSubject<number[]> {
        return this._$selectedNotes;
	}

	constructor() {
		this._$selectedNotes = new BehaviorSubject<number[]>([]);
		this.selectedNotes = [];
	}

	addToList(note: number) {
		this.selectedNotes.push(note);
		this.$selectedNotes.next(this.selectedNotes);
	}

	removeFromList(note: Note) {
		const noteToDelete = this.selectedNotes.find(item => item === note.noteid);
		this.selectedNotes = this.selectedNotes.slice(this.selectedNotes.indexOf(noteToDelete), 1);
		this.$selectedNotes.next(this.selectedNotes);
	}
}
