using System.ComponentModel.DataAnnotations;

namespace GraduateNotes.DataAccess.Contract.Models
{
    public class EventType
    {
        [Key]
        public string Type { get; set; }
    }
}
