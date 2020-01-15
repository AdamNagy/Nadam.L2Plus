using GraduateNotes.DataAccess.Contract.Models;

namespace GraduateNotes.DataAccess.Contract.Repositories
{
    public interface IUserRepository
    {
        UserEntity Add(UserEntity newUser);
        UserEntity Read(string email, string password);
        UserEntity Read(string email);
    }
}
