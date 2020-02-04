using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduateNotes.DataAccess.Contract.Models
{
    public class NoteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OwnerId { get; set; }
        public UserEntity Owner { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public int Type { get; set; }
    }
}
