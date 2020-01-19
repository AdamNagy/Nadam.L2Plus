import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class HeaderManager {

	// tslint:disable-next-line:variable-name
	private $_editingMode: Subject<boolean>;
    get $editingMode(): Subject<boolean> {
        return this.$_editingMode;
	}

	// tslint:disable-next-line:variable-name
	private $_loggedIn: Subject<boolean>;
    get $loggedIn(): Subject<boolean> {
        return this.$_loggedIn;
	}

	constructor() {
		this.$_editingMode = new Subject<boolean>();
		this.$_loggedIn = new Subject<boolean>();
	}

	public turnOnEditingMode(): void {
		this.$_editingMode.next(true);
	}

	public turnOffEditingMode(): void {
		this.$_editingMode.next(false);
	}

	public logIn(): void {
		this.$_loggedIn.next(true);
	}

	public logOut(): void {
		this.$_loggedIn.next(false);
	}
}
