using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduateNotes.DataAccess.Contract.Models
{
    public class NoteSharing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OwnerId { get; set; }
        public UserEntity Owner { get; set; }

   
        public int SharedWithId { get; set; }
        public UserEntity SharedWith { get; set; }

    
        public int NoteId { get; set; }
        public NoteEntity Note { get; set; }
    }
}
