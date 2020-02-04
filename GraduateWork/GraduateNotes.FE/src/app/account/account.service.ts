import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginRequestModel, AccountModel, RegisterRequestModel } from './account.model';
import { Observable, of, BehaviorSubject, Subject } from 'rxjs';
import * as _ from 'lodash';
import { environment } from '../../environments/environment';
import { CanActivate, ActivatedRouteSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

	constructor(private http: HttpClient) {
	}

	public login(requestModel: LoginRequestModel): Observable<AccountModel> {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type': 'application/json'
			})
		};

		return this.http.post<AccountModel>(`${environment.accountAPi}/login`, requestModel, httpOptions);
	}

	public register(registerRequest: RegisterRequestModel): Observable<AccountModel> {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type': 'application/json'
			})
		};

		return this.http.post<AccountModel>(`${environment.accountAPi}/register`, registerRequest, httpOptions);
	}
}
