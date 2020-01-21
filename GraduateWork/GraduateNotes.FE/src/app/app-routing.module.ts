import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NoteGridComponent } from './notes/note-grid/note-grid.component';
import { NoteComponent } from './notes/note/note.component';
import { AccountManager } from './account/account.manager';

const routes: Routes = [
	{ path: '', redirectTo: '', pathMatch: 'full' },
	{ path: 'my-notes', component: NoteGridComponent, canActivate: [AccountManager] },
	{ path: 'new-note', component: NoteComponent, canActivate: [AccountManager] },
	{ path: 'my-notes/:id', component: NoteComponent, canActivate: [AccountManager] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
