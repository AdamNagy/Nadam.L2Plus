import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginRequestModel, UserModel } from './account.model';
import { Observable, of, BehaviorSubject, Subject } from 'rxjs';
import * as _ from 'lodash';
import { environment } from '../../environments/environment';
import { CanActivate, ActivatedRouteSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService implements CanActivate  {

	private account: Observable<UserModel>;

	private token: string;
	private _$token: BehaviorSubject<string>;
	get $token(): BehaviorSubject<string> {
		return this._$token;
	}

	constructor(private http: HttpClient) {
		this._$token = new BehaviorSubject('');
	}

	canActivate(route: ActivatedRouteSnapshot): boolean {
		if ( this.token === undefined) {
			console.log('can not navigate, no token');
		}
		return this.token !== undefined;
	}

	public getAccount(): Observable<UserModel> {
		if (!this.account) {
			return of(null);
		}
		return this.account;
	}

	public login(requestModel: LoginRequestModel): void {
		const httpOptions = {
			headers: new HttpHeaders({
			  'Content-Type': 'application/json'
			})
		  };

		this.http.post<UserModel>(environment.accountAPi, requestModel, httpOptions)
			.subscribe(account => {
				this.token = account.token;
				this._$token.next(account.token);
			});
	}

	public logOut(): void {
		this.account = null;
	}
}
