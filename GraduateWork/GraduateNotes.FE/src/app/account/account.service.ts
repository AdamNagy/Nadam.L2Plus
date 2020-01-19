import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginRequestModel, UserModel } from './account.model';
import { Observable, of, BehaviorSubject } from 'rxjs';
import * as _ from 'lodash';
import { environment } from '../../environments/environment';
import { NoteService } from '../notes/note.service';
import { CanActivate, ActivatedRouteSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService implements CanActivate  {

	private account: Observable<UserModel>;

	// tslint:disable-next-line:variable-name
	private _token: string;
	get token(): string {
        return this._token;
    }

	constructor(private http: HttpClient) {	}

	canActivate(route: ActivatedRouteSnapshot): boolean {
		return this._token !== undefined;
	}

	public getAccount(): Observable<UserModel> {
		if (!this.account) {
			return of(null);
		}
		return this.account;
	}

	public login(requestModel: LoginRequestModel): Observable<UserModel> {
		this.account = this.sendLoginRequest(requestModel);
		return this.account;
	}

	public logOut(): void {
		this.account = null;
	}

	private sendLoginRequest(requestModel: LoginRequestModel): Observable<UserModel> {
		const httpOptions = {
			headers: new HttpHeaders({
			  'Content-Type': 'application/json'
			})
		  };

		const accObs = this.http.post<UserModel>(environment.accountAPi, requestModel, httpOptions);
		accObs.subscribe(account => {
			this._token = account.token;
		});

		return accObs;
	}

}
