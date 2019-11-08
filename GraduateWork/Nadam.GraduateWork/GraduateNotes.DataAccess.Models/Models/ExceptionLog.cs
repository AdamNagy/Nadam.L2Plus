using System;
using System.ComponentModel.DataAnnotations;

namespace GraduateNotes.DataAccess.Contract.Models
{
    public class ExceptionLog
    {
        [Key]
        public int Id { get; set; }
        public DateTime HappendOn { get; set; }

        public ExceptionType ExceptionType { get; set; }
        public string Message { get; set; }
    }
}
