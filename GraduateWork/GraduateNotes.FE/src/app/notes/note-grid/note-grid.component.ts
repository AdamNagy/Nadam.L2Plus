import { Component, OnInit } from '@angular/core';
import { Note } from '../note.model';
import { NoteService } from '../note.service';
import { AccountService } from '../../account/account.service';
import { Router } from '@angular/router';
import { NoteManager } from '../note.manager';

@Component({
	// tslint:disable-next-line:component-selector
	selector: 'note-grid',
	templateUrl: './note-grid.component.html',
	styleUrls: ['./note-grid.component.scss']
})
export class NoteGridComponent implements OnInit {

	private notes: Note[] = [];

	constructor(
		private noteManager: NoteManager,
		private router: Router) {
	}

	ngOnInit() {
		this.noteManager.getNotes();
		this.noteManager.$notes.subscribe(notes => {
			this.notes = notes;
		});
	}

	private openNote(noteId) {
		console.log(noteId);
		this.router.navigateByUrl(`/my-notes/${noteId}`);
	}
}
