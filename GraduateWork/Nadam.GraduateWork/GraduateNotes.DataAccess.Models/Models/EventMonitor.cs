using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GraduateNotes.DataAccess.Contract.Models
{
    public class EventMonitor
    {
        [Key]
        public int Id { get; set; }

        public EventType EventType { get; set; }
        public UserEntity Account { get; set; }
        public DateTime Occure { get; set; }
    }
}
