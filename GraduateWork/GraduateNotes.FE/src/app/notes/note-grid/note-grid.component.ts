import { Component, OnInit } from '@angular/core';
import { Note } from '../note.model';
import { NoteService } from '../note.service';
import { AccountService } from '../../account/account.service';

@Component({
	// tslint:disable-next-line:component-selector
	selector: 'note-grid',
	templateUrl: './note-grid.component.html',
	styleUrls: ['./note-grid.component.scss']
})
export class NoteGridComponent implements OnInit {

	private notes: Note[] = [];

	constructor(
		private service: NoteService,
		private accountService: AccountService) {
	}

	ngOnInit() {
		const token = this.accountService.token;
		this.notes = this.service.get(token);
		this.service.$notes.subscribe(notes => {
			this.notes = notes;
		});
	}
}
