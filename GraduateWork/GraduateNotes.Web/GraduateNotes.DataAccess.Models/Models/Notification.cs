using System;
using System.ComponentModel.DataAnnotations;

namespace GraduateNotes.DataAccess.Contract.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public UserEntity Notified { get; set; }
        public NoteEntity NoteId { get; set; }
        public DateTime Occur { get; set; }
    }
}
