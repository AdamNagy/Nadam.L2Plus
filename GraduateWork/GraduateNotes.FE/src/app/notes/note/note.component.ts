import { Component } from '@angular/core';
import { Note, NoteType } from '../note.model';
import { NoteManager } from '../note.manager';

@Component({
	selector: 'note',
	templateUrl: './note.component.html',
	styleUrls: ['./note.component.scss']
})
export class NoteComponent {

	private note: Note;
	private content: string;

	constructor(private manager: NoteManager) {
		this.note = new Note();
		this.note.Type = NoteType.text;
		this.note.Created = new Date();
	}

	updateLocal() {

	}

	public onContentChange(content: string) {
		this.note.Content = content;
		this.manager.updateLocal(this.note);
	}
}
