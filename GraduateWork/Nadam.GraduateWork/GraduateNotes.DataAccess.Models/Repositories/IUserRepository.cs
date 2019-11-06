using GraduateNotes.DataAccess.Contracts.Models;

namespace GraduateNotes.DataAccess.Contract.Repositories
{
    public interface IUserRepository
    {
        UserEntity FindUser(string email, string password);
        UserEntity FindUser(string email);
    }
}
