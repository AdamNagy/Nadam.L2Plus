import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AccountService } from './account.service';
import { LoginRequestModel, UserModel } from './account.model';
import { CanActivate, ActivatedRouteSnapshot } from '@angular/router';

@Injectable({
	providedIn: 'root'
})
export class AccountManager implements CanActivate  {
	private account: UserModel;
	public token: string;
	private _$token: BehaviorSubject<string>;
	get $token(): BehaviorSubject<string> {
		return this._$token;
	}

	constructor(private service: AccountService) {
		this._$token = new BehaviorSubject('');
	}

	login(requestModel: LoginRequestModel): void {
		this.service.login(requestModel)
		.subscribe(account => {
			this.account = account;
			this.token = account.token;
			this._$token.next(this.token);
		});
	}

	canActivate(route: ActivatedRouteSnapshot): boolean {
		if ( this.token === undefined) {
			console.log('can not navigate, no token');
		}
		return this.token !== undefined;
	}
}
