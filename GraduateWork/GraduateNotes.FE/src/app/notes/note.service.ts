import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Subject, Observable, BehaviorSubject } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Note } from './note.model';
import { environment } from 'src/environments/environment';
import { AccountService } from '../account/account.service';

@Injectable({
	providedIn: 'root'
})
export class NoteService {

	private notes: Note[];
	private _$notes: BehaviorSubject<Note[]>;
    get $notes(): BehaviorSubject<Note[]> {
        return this._$notes;
    }

	constructor(private http: HttpClient) {
		this.notes = [];
		this._$notes = new BehaviorSubject<Note[]>(this.notes);
	}

	public get(token: string): void {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type':  'application/json',
				'Authorization': 'Bearer ' + token
			})
		};

		this.http.get<Note[]>(`${environment.noteApi}/get`, httpOptions)
			.subscribe(notes => {
				this.notes = notes;
				this._$notes.next(this.notes);
			});
	}

	public post(note: Note, token: string): Observable<Note> {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type':  'application/json',
				'Authorization': 'Bearer ' + token
			})
		};

		const postOBservable = this.http.post<Note>(`${environment.noteApi}/post`, note, httpOptions);

		postOBservable.subscribe(newNote => {
			this.notes.push(newNote);
			this._$notes.next(this.notes);
		});

		return postOBservable;
	}

	public patch(note: Note, token: string): Observable<Note> {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type':  'application/json',
				'Authorization': 'Bearer ' + token
			})
		};

		const postOBservable = this.http.post<Note>(`${environment.noteApi}/patch`, note, httpOptions);

		postOBservable.subscribe(newNote => {
			this.notes.push(newNote);
			this._$notes.next(this.notes);
		});

		return postOBservable;
	}

	public getNoteById(id: number): Note {
		return this.notes.find(item => item.Id === id);
	}
}
