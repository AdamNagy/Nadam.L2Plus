import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';
import { AccountService } from './account.service';
import { LoginRequestModel, AccountModel, RegisterRequestModel, AccountStateModel } from './account.model';
import { CanActivate, ActivatedRouteSnapshot } from '@angular/router';
import { HeaderManager } from '../header/header.manager';

@Injectable({
	providedIn: 'root'
})
export class AccountManager implements CanActivate {

	public account: AccountModel;
	private _$account: Subject<AccountModel>;
	get $account(): Subject<AccountModel> {
		return this._$account;
	}

	constructor(
		private service: AccountService,
		private headerManager: HeaderManager
	) {
		this._$account = new Subject<AccountModel>();
	}

	login(requestModel: LoginRequestModel): void {
		// this.service.login(requestModel)
		// 	.subscribe(
		// 		account => {
		// 			this.account = {
		// 				account,
		// 				success: true,
		// 				errorMessage: ''
		// 				};
		// 			this.$account.next(this.account);
		// 		},
		// 		error => {
		// 			this.headerManager.showErrorLayer('Login failed, please try again later');
		// 			this.account = {
		// 				account: undefined,
		// 				success: false,
		// 				errorMessage: error
		// 				};
		// 			this.$account.next(this.account);
		// 		}
		// 	);
		this.service.login(requestModel)
					.subscribe(this._$account);
	}

	register(requestModel: RegisterRequestModel) {
		// this.service.register(requestModel)
		// 	.subscribe(
		// 		account => {
		// 			this.account = {
		// 				account,
		// 				success: true,
		// 				errorMessage: ''
		// 				};
		// 			this.$account.next(this.account);
		// 		},
		// 		error => {
		// 			this.headerManager.showErrorLayer('Login failed, please try again later');
		// 			this.account = {
		// 				account: undefined,
		// 				success: false,
		// 				errorMessage: error
		// 				};
		// 			this.$account.next(this.account);
		// 		});
		this.service.register(requestModel)
					.subscribe(this._$account);
	}
	logout() {
		this.account = undefined;
		this._$account.next(undefined);
	}

	canActivate(route: ActivatedRouteSnapshot): boolean {
		if ( this.account === undefined) {
			console.log('can not navigate, no token');
		}
		return this.account !== undefined;
	}
}
