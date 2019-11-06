using System.ComponentModel.DataAnnotations;

namespace GraduateNotes.DataAccess.Contracts.Models
{
    public class UserEntity
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
