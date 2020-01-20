import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class HeaderManager {

	private _$editingMode: Subject<boolean>;
    get $editingMode(): Subject<boolean> {
        return this._$editingMode;
	}

	private _$loggedIn: Subject<boolean>;
    get $loggedIn(): Subject<boolean> {
        return this._$loggedIn;
	}

	private _$showLoadingLayer: Subject<boolean>;
    get $showLoadingLayer(): Subject<boolean> {
        return this._$showLoadingLayer;
	}

	constructor() {
		this._$editingMode = new Subject<boolean>();
		this._$loggedIn = new Subject<boolean>();
		this._$showLoadingLayer = new Subject<boolean>();
	}

	public turnOnEditingMode(): void {
		this._$editingMode.next(true);
	}

	public turnOffEditingMode(): void {
		this._$editingMode.next(false);
	}

	public logIn(): void {
		this._$loggedIn.next(true);
	}

	public logOut(): void {
		this._$loggedIn.next(false);
	}

	public showLoadingLayer() {
		this._$showLoadingLayer.next(true);
	}

	public hideLoadingLayer() {
		this._$showLoadingLayer.next(false);
	}
}
