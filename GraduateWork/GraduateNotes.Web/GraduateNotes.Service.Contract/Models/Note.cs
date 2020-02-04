using System;

namespace GraduateNotes.Service.Contract.Models
{
    public class Note
    {
        public int Noteid { get; set; }
        public string Content { get; set; }
        public NoteType Type { get; set; }
        public DateTime Created { get; set; }

        public Note()
        {

        }

        public Note(int id)
        {
            Noteid = id;
        }
    }
}
