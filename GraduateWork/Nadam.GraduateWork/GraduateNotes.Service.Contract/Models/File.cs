namespace GraduateNotes.Service.Contract.Models
{
    public class File
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }
        public bool Exist { get; set; }
    }
}
