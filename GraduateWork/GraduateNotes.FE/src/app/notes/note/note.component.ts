import { Component, OnInit, OnDestroy } from '@angular/core';
import { Note, NoteType } from '../note.model';
import { NoteManager } from '../note.manager';
import { ActivatedRoute } from '@angular/router';
import { NoteService } from '../note.service';
import { HeaderManager } from 'src/app/header/header.manager';

@Component({
	// tslint:disable-next-line:component-selector
	selector: 'note',
	templateUrl: './note.component.html',
	styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {

	private note: Note;
	private content: string;

	constructor(
		private noteManager: NoteManager,
		private noteService: NoteService,
		private route: ActivatedRoute,
		private headerManager: HeaderManager
	) {

	}

	ngOnInit() {
		this.headerManager.turnOnEditingMode();
		const id = +this.route.snapshot.paramMap.get('id');
		this.note = this.noteManager.getNoteById(id);

		if (this.note === undefined) {
			this.note = new Note();
			this.note.Type = NoteType.text;
			this.note.Created = new Date();
			this.note.Content = '';
		}

		this.noteManager.updateLocal(this.note);
	}

	// ngOnDestroy() {
	// 	this.headerManager.turnOffEditingMode();
	// }

	public onContentChange(content: string) {
		this.note.Content = content;
		this.noteManager.updateLocal(this.note);
	}
}
