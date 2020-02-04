import { Component, OnInit, TemplateRef, HostBinding } from '@angular/core';
import { HeaderManager } from './header.manager';
import { Router } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { NoteManager } from '../notes/note.manager';
import { AccountManager } from '../account/account.manager';
import { filter, map } from 'rxjs/operators';
import { resolve } from 'url';

@Component({
	// tslint:disable-next-line:component-selector
	selector: 'header-bar',
	templateUrl: './header.component.html',
	styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

	@HostBinding('class') backgroundColor = 'position-sticky';

	private isLoggedIn: boolean;
	private isEditing: boolean;
	private email: string;
	public modalRef: BsModalRef;

	constructor(
		private accountManager: AccountManager,
		private noteManager: NoteManager,
		private manager: HeaderManager,
		private router: Router,
		private modalService: BsModalService) {

	}

	ngOnInit() {
		this.manager.$editingMode
			.subscribe(value => {
				this.isEditing = value;
			});

		this.accountManager.$account
			.pipe(
				filter(response => response !== undefined),
				filter(response => response.success),
				map(response => response.account)
			)
			.subscribe(account => {
				this.email = account.email;
				this.manager.hideLoadingLayer();

				if ( this.modalRef ) {
					this.modalRef.hide();
				}

				this.router.navigateByUrl('/my-notes');
			});
	}

	public loginHandler(email, password): void {
		this.manager.showLoadingLayer();
		this.accountManager.login({email, password});
	}

	public logoutHandler() {
		this.accountManager.logout();
		this.noteManager.reset();
		this.router.navigateByUrl('/');
	}

	public registerHandler(email, password): void {
		this.manager.showLoadingLayer();
		this.accountManager.register({ email, password });
	}

	public createNoteHandler(): void {
		this.manager.turnOnEditingMode();
		this.router.navigateByUrl('/new-note');
	}

	public cancelHandler(): void {
		this.manager.turnOffEditingMode();
		this.router.navigateByUrl('/my-notes');
	}

	public openModal(template: TemplateRef<any>) {
        this.modalRef = this.modalService.show(template);
	}

	public saveHandler() {
		this.manager.showLoadingLayer();  // kinda an effect of save note
		this.noteManager.saveCurrent();

		// this.noteManager.$saveSuccess.subscribe(() => {
			// this.manager.hideLoadingLayer();
			// this.manager.turnOffEditingMode();
			// this.router.navigateByUrl('/my-notes');
		// });
	}
}
