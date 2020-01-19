import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Subject } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Note } from './note.model';
import { environment } from 'src/environments/environment';
import { AccountService } from '../account/account.service';

@Injectable({
	providedIn: 'root'
})
export class NoteService {

	private notes: Note[];
	// tslint:disable-next-line:variable-name
	private $_notes: Subject<Note[]>;
    get $notes(): Subject<Note[]> {
        return this.$_notes;
    }

	constructor(
		private http: HttpClient,
		private accountService: AccountService) {
			this.$_notes = new Subject<Note[]>();
	}

	public get(token: string = ''): Note[] | undefined {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type':  'application/json',
				// tslint:disable-next-line:object-literal-key-quotes
				'Authorization': 'Bearer ' + token || this.accountService.token
			})
		};

		if ( this.notes ) {
			this.$_notes.next(this.notes);
			return this.notes;
		} else {
			this.http.get<Note[]>(`${environment.noteApi}/get`, httpOptions)
				.pipe(
					retry(3)
				).subscribe(notes => {
					this.notes = notes;
					this.$_notes.next(this.notes);
				});
		}
	}

	public save(note: Note, token: string): boolean {
		const httpOptions = {
			headers: new HttpHeaders({
				'Content-Type':  'application/json',
				// tslint:disable-next-line:object-literal-key-quotes
				'Authorization': 'Bearer ' + token || this.accountService.token
			})
		};

		this.http.post<Note>(`${environment.noteApi}/post`, httpOptions)
			.pipe(
				retry(3)
			).subscribe(notes => {
				this.notes = notes;
				this.$_notes.next(this.notes);
			});
	}
}
