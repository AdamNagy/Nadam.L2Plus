namespace GraduateNotes.Service.Contract.Models
{
    public class Note
    {
        public string Id { get; }
        public int Owner { get; set; }
        public string PublicUrl { get; set; }
        public string Content { get; set; }
        public NoteType Type { get; set; }
    }
}
