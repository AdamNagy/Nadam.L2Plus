using System.ComponentModel.DataAnnotations;

namespace GraduateNotes.DataAccess.Contract.Models
{
    public class NoteSharing
    {
        [Key]
        public int Id { get; set; }

        public int OwnerId { get; set; }
        public UserEntity Owner { get; set; }

       
        public int SharedWithId { get; set; }
        public UserEntity SharedWith { get; set; }

       
        public int NoteId { get; set; }
        public NoteEntity Note { get; set; }
    }
}
