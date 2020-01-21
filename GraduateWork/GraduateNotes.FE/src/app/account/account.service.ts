import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginRequestModel, UserModel, RegisterRequestModel } from './account.model';
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

	public login(requestModel: LoginRequestModel): Observable<UserModel> {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type': 'application/json'
			})
		};

		return this.http.post<UserModel>(`${environment.accountAPi}/login`, requestModel, httpOptions);
	}

	public register(registerRequest: RegisterRequestModel): Observable<UserModel> {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type': 'application/json'
			})
		};

		return this.http.post<UserModel>(`${environment.accountAPi}/register`, registerRequest, httpOptions);
	}
}
