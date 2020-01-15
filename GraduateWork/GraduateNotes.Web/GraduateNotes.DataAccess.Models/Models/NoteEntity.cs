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
        public string FileTitle { get; set; }

        public DateTime Created { get; set; }

        public string PublicUrl { get; set; }
    }
}
