import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AccountService } from './account.service';
import { LoginRequestModel, UserModel, RegisterRequestModel } from './account.model';
import { CanActivate, ActivatedRouteSnapshot } from '@angular/router';
import { HeaderManager } from '../header/header.manager';

@Injectable({
	providedIn: 'root'
})
export class AccountManager implements CanActivate  {

	public token: string;
	private _$token: BehaviorSubject<string>;
	get $token(): BehaviorSubject<string> {
		return this._$token;
	}

	public account: UserModel;
	private _$account: BehaviorSubject<UserModel>;
	get $account(): BehaviorSubject<UserModel> {
		return this._$account;
	}

	constructor(
		private service: AccountService,
		private headerManager: HeaderManager) {
		this._$token = new BehaviorSubject('');
		this._$account = new BehaviorSubject<UserModel>(undefined);
	}

	login(requestModel: LoginRequestModel): void {
		this.service.login(requestModel)
			.subscribe(account => {
				this.account = account;
				this.token = account.token;
				this._$token.next(this.token);
				this.$account.next(this.account);
			});
	}

	register(requestModel: RegisterRequestModel) {
		this.service.register(requestModel)
			.subscribe(account => {
				this.account = account;
				this.token = account.token;
				this._$token.next(this.token);
				this.$account.next(this.account);
			});
	}

	logout() {
		this.token = '';
		this.headerManager.logOut();
		this._$account.next(undefined);
	}

	canActivate(route: ActivatedRouteSnapshot): boolean {
		if ( this.token === undefined) {
			console.log('can not navigate, no token');
		}
		return this.token !== undefined;
	}
}
