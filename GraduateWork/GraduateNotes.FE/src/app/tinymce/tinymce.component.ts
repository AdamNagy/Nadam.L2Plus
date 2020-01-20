import { Component, Input, EventEmitter, Output } from '@angular/core';

@Component({
	// tslint:disable-next-line:component-selector
	selector: 'tinymce',
	templateUrl: './tinymce.component.html',
	styleUrls: ['./tinymce.component.scss']
})
export class TinymceComponent {
	tinyMceInitConfig = {
		height: 500,
		menubar: true,
		plugins: [
		  'advlist autolink lists link image charmap print preview anchor',
		  'searchreplace visualblocks code fullscreen',
		  'insertdatetime media table paste code help wordcount'
		],
		toolbar:
		  'undo redo | formatselect | bold italic backcolor | \
		  alignleft aligncenter alignright alignjustify | \
		  bullist numlist outdent indent | removeformat | help'
	};

	// content: string;

	@Input() initialContent: string;
	// tslint:disable-next-line:variable-name
	private _content: string;
	@Output() contentChange = new EventEmitter<string>();

	constructor() {
		if ( this.initialContent === undefined || '' ) {
			this.initialContent = '<p>Write and format your note here</p>';
		}
	}

	private getContent(event): void {
	  // console.log(event.editor.getContent());
	  this._content = event.editor.getContent();
	  this.contentChange.emit(this._content);
	}
}
