using System;
using System.Collections.Generic;
using System.Text;

namespace GraduateNotes.Core.AccountDomain
{
    public class LoginRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
