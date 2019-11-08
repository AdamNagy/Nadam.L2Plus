using System.ComponentModel.DataAnnotations;

namespace GraduateNotes.DataAccess.Contract.Models
{
    public class ExceptionType
    {
        [Key]
        public string Type { get; set; }
    }
}
