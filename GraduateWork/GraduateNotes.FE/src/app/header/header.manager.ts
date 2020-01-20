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

	private $_loggedIn: Subject<boolean>;
    get $loggedIn(): Subject<boolean> {
        return this.$_loggedIn;
	}

	constructor() {
		this._$editingMode = new Subject<boolean>();
		this.$_loggedIn = new Subject<boolean>();
	}

	public turnOnEditingMode(): void {
		this._$editingMode.next(true);
	}

	public turnOffEditingMode(): void {
		this._$editingMode.next(false);
	}

	public logIn(): void {
		this.$_loggedIn.next(true);
	}

	public logOut(): void {
		this.$_loggedIn.next(false);
	}
}
