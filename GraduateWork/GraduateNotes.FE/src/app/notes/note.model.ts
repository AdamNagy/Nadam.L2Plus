export enum NoteType {
	text = 1,
	drawing = 2
}

export class Note {
	public Id: number;
	public Content: string;
	public Created: Date;
	public Type: NoteType;
}
