import { Component, TemplateRef, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { HeaderManager } from './header/header.manager';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

    private title = 'Notesbook';
	// private showLoadingLayer: boolean;
	public modalRef: BsModalRef;

	constructor(
		private manager: HeaderManager) {
			// this.showLoadingLayer = false;
		 }

	 ngOnInit() {
		// this.manager.$showLoadingLayer.subscribe(value => {
		// 	this.showLoadingLayer = value;
		// });
	 }
}
