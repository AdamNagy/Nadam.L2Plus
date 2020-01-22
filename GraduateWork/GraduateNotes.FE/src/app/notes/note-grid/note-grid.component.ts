import { Component, OnInit, TemplateRef } from '@angular/core';
import { Note } from '../note.model';
import { Router } from '@angular/router';
import { NoteManager } from '../note.manager';
import { HeaderManager } from 'src/app/header/header.manager';
import { SelectionListManager } from 'src/app/selection-list/selection-list.manager';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';

@Component({
	// tslint:disable-next-line:component-selector
	selector: 'note-grid',
	templateUrl: './note-grid.component.html',
	styleUrls: ['./note-grid.component.scss']
})
export class NoteGridComponent implements OnInit {

	private notes: Note[] = [];
	private selectedForSharing: number;
	public modalRef: BsModalRef;

	constructor(
		private noteManager: NoteManager,
		private headerManager: HeaderManager,
		private selectionManager: SelectionListManager,
		private router: Router,
		private modalService: BsModalService) {
	}

	ngOnInit() {
		this.noteManager.getNotes();
		this.noteManager.$notes.subscribe(notes => {
			this.notes = notes;
			this.headerManager.hideLoadingLayer();
		});

		this.noteManager.$saveSuccess.subscribe(item => {
			if (this.modalRef) {
				this.modalRef.hide();
			}
		});
	}

	private openNote(noteId) {
		console.log(noteId);
		this.router.navigateByUrl(`/my-notes/${noteId}`);
	}

	private delete(noteId) {
		this.headerManager.showLoadingLayer();
		this.noteManager.delete(noteId);
	}

	private select(noteId) {
		this.selectionManager.addToList(noteId);
	}

	public openSharingModal(noteId: number, template: TemplateRef<any>) {
		this.modalRef = this.modalService.show(template);
		this.selectedForSharing = noteId;
	}

	private shareNote(partneremail) {
		this.noteManager.shareNote(partneremail, this.selectedForSharing);
	}
}
