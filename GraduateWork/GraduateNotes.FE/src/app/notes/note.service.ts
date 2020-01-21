import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  Observable } from 'rxjs';
import { Note } from './note.model';
import { environment } from 'src/environments/environment';

@Injectable({
	providedIn: 'root'
})
export class NoteService {

	constructor(private http: HttpClient) {
	}

	public get(token: string): Observable<Note[]> {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type':  'application/json',
				'Authorization': 'Bearer ' + token
			})
		};

		return this.http.get<Note[]>(`${environment.noteApi}/get`, httpOptions);
	}

	public post(note: Note, token: string): Observable<Note> {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type':  'application/json',
				'Authorization': 'Bearer ' + token
			})
		};

		return this.http.post<Note>(`${environment.noteApi}/post`, note, httpOptions);
	}

	public patch(note: Note, token: string): Observable<Note> {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type':  'application/json',
				'Authorization': 'Bearer ' + token
			})
		};

		return this.http.patch<Note>(`${environment.noteApi}/patch`, note, httpOptions);
	}

	public delete(noteId: number, token: string): Observable<boolean> {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type':  'application/json',
				'Authorization': 'Bearer ' + token
			})
		};

		return this.http.delete<boolean>(`${environment.noteApi}/delete/${noteId}`, httpOptions);
	}

	public deleteThese(notes: Note[], token: string): Observable<boolean> {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type':  'application/json',
				'Authorization': 'Bearer ' + token
			})
		};

		return this.http.delete<boolean>(`${environment.noteApi}/delete`, httpOptions);
	}

	public shareNoteWith(note: Note, who: string, token: string): Observable<boolean> {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type':  'application/json',
				'Authorization': 'Bearer ' + token
			})
		};

		return this.http.post<boolean>(`${environment.noteApi}/post`, note, httpOptions);
	}

	public getSharableLinkFor(note: Note, token: string): Observable<string> {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type':  'application/json',
				'Authorization': 'Bearer ' + token
			})
		};

		return this.http.get<string>(`${environment.noteApi}/get/${note.noteid}/link`, httpOptions);
	}
}
