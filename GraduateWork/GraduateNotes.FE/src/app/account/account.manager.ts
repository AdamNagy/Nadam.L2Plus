import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/map';
import { AccountService } from './account.service';
import { LoginRequestModel, AccountModel, RegisterRequestModel, LoginResponseModel } from './account.model';
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
		this.service.login(requestModel)
					.do((response: LoginResponseModel) => {if ( !response.success ) { console.log('shit happens'); }})
					.filter((response: LoginResponseModel) => !response.success)
					.map((response: LoginResponseModel) => response.account)
					.subscribe(this._$account);
	}

	register(requestModel: RegisterRequestModel) {

		// maybe fire some action before as well to be able to show spinner or loading layer

		this.service.login(requestModel)
					.do((response: LoginResponseModel) => {if ( !response.success ) { console.log('shit happens'); }})
					.filter((response: LoginResponseModel) => !response.success)
					.map((response: LoginResponseModel) => response.account)
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
