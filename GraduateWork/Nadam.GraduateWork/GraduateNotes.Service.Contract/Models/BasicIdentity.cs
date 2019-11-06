using Microsoft.AspNetCore.Identity;

namespace GraduateNotes.Service.Contract.Model
{
    public class BasicIdentity : IdentityUser
    {
        public string Password { get; set; }
        public string Token { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
