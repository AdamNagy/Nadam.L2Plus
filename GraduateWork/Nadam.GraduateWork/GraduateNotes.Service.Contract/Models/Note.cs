using GraduateNotes.Service.Contract.Models;

namespace GraduateNotes.Service.Contract.Model
{
    public class Note
    {
        public string Id { get; }
        public int Owner { get; set; }
        public string FileTitle { get; set; }
        public string PublicUrl { get; set; }
        public File Content { get; set; }
    }
}
