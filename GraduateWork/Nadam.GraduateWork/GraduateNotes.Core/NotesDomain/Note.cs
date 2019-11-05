using System;

namespace GraduateNotes.Core
{
    public class Note
    {
        public int Id { get; }
        public string Owner { get; set; }
        public NoteType Type { get; set; }
        public string Url { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
    }
}
