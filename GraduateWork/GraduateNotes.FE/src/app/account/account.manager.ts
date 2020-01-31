import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';
import { AccountService } from './account.service';
import { LoginRequestModel, UserModel, RegisterRequestModel } from './account.model';
import { CanActivate, ActivatedRouteSnapshot } from '@angular/router';

@Injectable({
	providedIn: 'root'
})
export class AccountManager implements CanActivate  {


	public account: UserModel;
	private _$account: BehaviorSubject<UserModel>;
	get $account(): BehaviorSubject<UserModel> {
		return this._$account;
	}

	private _$error: Subject<any>;
	get $error(): Subject<any> {
		return this._$error;
	}

	constructor(
		private service: AccountService
	) {
		this._$account = new BehaviorSubject<UserModel>(undefined);
		this._$error = new Subject<UserModel>();
	}

	login(requestModel: LoginRequestModel): void {
		this.service.login(requestModel)
			.subscribe(
				account => {
					this.account = account;
					this.$account.next(this.account);
				},
				error => {
					console.log('error happend');
					this.$error.next(error);
				},
				() => console.log('HTTP request completed.')
			);
	}

	register(requestModel: RegisterRequestModel) {
		this.service.register(requestModel)
			.subscribe(
				account => {
					this.account = account;
					this.$account.next(this.account);
				},
				error => {
					console.log('error happend');
					this.$error.next(error);
				});
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
