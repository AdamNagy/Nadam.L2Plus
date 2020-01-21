import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';

import { EditorModule } from '@tinymce/tinymce-angular';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { CollapseModule } from 'ngx-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { NoteGridComponent } from './notes/note-grid/note-grid.component';
import { NoteComponent } from './notes/note/note.component';
import { HeaderComponent } from './header/header.component';
import { TinymceComponent } from './tinymce/tinymce.component';
import { LoadingLayerComponent } from './loading-layer/loading-layer.component';
import { SelectionListComponent } from './selection-list/selection-list.component';

@NgModule({
  declarations: [
	AppComponent,
	NoteGridComponent,
	NoteComponent,
	HeaderComponent,
	TinymceComponent,
	LoadingLayerComponent,
	SelectionListComponent
  ],
  imports: [
	HttpClientModule,
	CollapseModule.forRoot(),
    BrowserModule,
	BrowserAnimationsModule,
  	AppRoutingModule,
	BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
	ModalModule.forRoot(),
	EditorModule
  ],
  providers: [],
  bootstrap: [ AppComponent ]
})
export class AppModule {}
