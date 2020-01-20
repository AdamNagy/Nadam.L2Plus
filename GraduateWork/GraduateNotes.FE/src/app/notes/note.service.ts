import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Subject, Observable } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Note } from './note.model';
import { environment } from 'src/environments/environment';
import { AccountService } from '../account/account.service';

@Injectable({
	providedIn: 'root'
})
export class NoteService {

	private notes: Note[];
	private _$notes: Subject<Note[]>;
    get $notes(): Subject<Note[]> {
        return this._$notes;
    }

	constructor(
		private http: HttpClient) {
			this._$notes = new Subject<Note[]>();
	}

	public get(token: string): Note[] | undefined {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type':  'application/json',
				'Authorization': 'Bearer ' + token
			})
		};

		if ( this.notes ) {
			this._$notes.next(this.notes);
			return this.notes;
		} else {
			this.http.get<Note[]>(`${environment.noteApi}/get`, httpOptions)
				.pipe(
					retry(3)
				).subscribe(notes => {
					this.notes = notes;
					this._$notes.next(this.notes);
				});
		}
	}

	public post(note: Note, token: string): Observable<Note> {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type':  'application/json',
				'Authorization': 'Bearer ' + token
			})
		};

		const postOBservable = this.http.post<Note>(`${environment.noteApi}/post`, note, httpOptions)
			.pipe(
				retry(3)
			);

		postOBservable.subscribe(newNote => {
			this.notes.push(newNote);
			this._$notes.next(this.notes);
		});

		return postOBservable;
	}
}
