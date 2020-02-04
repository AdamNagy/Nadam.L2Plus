import { Component, OnInit } from '@angular/core';
import { HeaderManager } from '../header/header.manager';

@Component({
	// tslint:disable-next-line:component-selector
	selector: 'focus-layer',
	templateUrl: './focus-layer.component.html',
	styleUrls: ['./focus-layer.component.scss']
})
export class FocusLayerComponent implements OnInit {

	private layerVisible: boolean;
	private showLoading: boolean;
	private message: string;

	constructor(private headerManager: HeaderManager) {

	}

	public ngOnInit() {
		this.headerManager.$showErrorLayer.subscribe(message => {
			this.showLoading = false;
			this.layerVisible = true;
			this.message = message;
		});

		this.headerManager.$showLoadingLayer.subscribe((event: boolean) => {
			this.showLoading = true;
			this.layerVisible = event;
		});
	}

	private hideLayer() {
		this.layerVisible = false;
	}
}
