using GraduateNotes.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateNotes.API.Authentication
{
    public interface IUserService
    {
        BasicIdentity Authenticate(string username, string password);
        BasicIdentity Create(BasicIdentity user, string password);
        IEnumerable<BasicIdentity> GetAll();
    }
}
