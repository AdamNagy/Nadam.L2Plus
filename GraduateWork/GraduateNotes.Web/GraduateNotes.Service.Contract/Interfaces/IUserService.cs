using GraduateNotes.Service.Contract.Models;
using System.Collections.Generic;

namespace GraduateNotes.Service.Contract.Interfaces
{
    public interface IUserService
    {
        BasicIdentity Authenticate(string username, string password);
        BasicIdentity Register(BasicIdentity user, string password);
    }
}
