using Microsoft.AspNetCore.Identity;

namespace GraduateNotes.API.Authentication
{
    public class BasicIdentity : IdentityUser
    {
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
