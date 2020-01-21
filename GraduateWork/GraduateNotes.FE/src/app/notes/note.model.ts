export enum NoteType {
	text = 1,
	drawing = 2
}

export class Note {
	public noteid: number;
	public content: string;
	public created: Date;
	public type: NoteType;
}
