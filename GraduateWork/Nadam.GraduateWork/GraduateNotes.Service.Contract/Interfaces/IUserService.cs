using GraduateNotes.Service.Contract.Model;
using System.Collections.Generic;

namespace GraduateNotes.Service.Contract.Interfaces
{
    public interface IUserService
    {
        BasicIdentity Authenticate(string username, string password);
        // BasicIdentity Create(BasicIdentity user, string password);
        // IEnumerable<BasicIdentity> Get();
    }
}
