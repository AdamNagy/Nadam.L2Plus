import { Component, OnInit } from '@angular/core';
import { SelectionListManager } from './selection-list.manager';
import { Note } from '../notes/note.model';

@Component({
	// tslint:disable-next-line:component-selector
	selector: 'selection-list',
	templateUrl: './selection-list.component.html',
	styleUrls: ['./selection-list.component.scss']
})
export class SelectionListComponent implements OnInit {

	private notes: number[];

	constructor(private manager: SelectionListManager) {
		this.notes = [];
	}

	ngOnInit() {
		this.manager.$selectedNotes.subscribe(notes => {
			this.notes = notes;
		});
	}
}
