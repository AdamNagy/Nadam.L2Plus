import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NoteGridComponent } from './notes/note-grid/note-grid.component';
import { NoteComponent } from './notes/note/note.component';
import { AccountService } from './account/account.service';

const routes: Routes = [
	{ path: '', redirectTo: '', pathMatch: 'full' },
	{ path: 'my-notes', component: NoteGridComponent, canActivate: [AccountService] },
	{ path: 'new-note', component: NoteComponent, canActivate: [AccountService] },
	{ path: 'my-notes/:id', component: NoteComponent, canActivate: [AccountService] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
