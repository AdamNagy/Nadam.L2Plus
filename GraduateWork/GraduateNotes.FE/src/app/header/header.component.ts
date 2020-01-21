import { Component, OnInit, TemplateRef, HostBinding } from '@angular/core';
import { HeaderManager } from './header.manager';
import { AccountService } from '../account/account.service';
import { NoteService } from '../notes/note.service';
import { Router } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { NoteManager } from '../notes/note.manager';
import { AccountManager } from '../account/account.manager';

@Component({
	// tslint:disable-next-line:component-selector
	selector: 'header',
	templateUrl: './header.component.html',
	styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

	@HostBinding('class') backgroundColor = 'position-sticky';

	private isLoggedIn: boolean;
	private isEditing: boolean;

	public modalRef: BsModalRef;

	constructor(
		private accountManager: AccountManager,
		private noteManager: NoteManager,
		private manager: HeaderManager,
		private router: Router,
		private modalService: BsModalService) {

	}

	ngOnInit() {
		this.manager.$editingMode.subscribe(value => {
			this.isEditing = value;
		});

		this.manager.$loggedIn.subscribe(value => {
			this.isLoggedIn = value;
		});
	}

	public login(email, password): void {
		this.manager.showLoadingLayer();
		this.accountManager.login({Email: email, Password: password});

		this.accountManager.$token.subscribe(token => {
			console.log(`token is: ${token}`);

			if ( token !== '' ) {
				this.manager.logIn();
				this.manager.hideLoadingLayer();
				this.router.navigateByUrl('/my-notes');
			}

		}, () => this.manager.hideLoadingLayer());
	}

	// public reloadNotes(): void {
	// 	this.noteService.get(this.accountService.token);
	// }

	public createNote(): void {
		this.manager.turnOnEditingMode();
		this.router.navigateByUrl('/new-note');
	}

	public cancel(): void {
		this.manager.turnOffEditingMode();
		this.router.navigateByUrl('/my-notes');
	}

	public openModal(template: TemplateRef<any>) {
        this.modalRef = this.modalService.show(template);
	}

	public save() {
		this.noteManager.saveCurrent();
	}
}
