import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginRequestModel, AccountModel, RegisterRequestModel, LoginResponseModel } from './account.model';
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

	public login(requestModel: LoginRequestModel): Observable<LoginResponseModel> {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type': 'application/json'
			})
		};

		return this.http.post<LoginResponseModel>(`${environment.accountAPi}/login`, requestModel, httpOptions);
	}

	public register(registerRequest: RegisterRequestModel): Observable<LoginResponseModel> {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type': 'application/json'
			})
		};

		return this.http.post<LoginResponseModel>(`${environment.accountAPi}/register`, registerRequest, httpOptions);
	}
}
