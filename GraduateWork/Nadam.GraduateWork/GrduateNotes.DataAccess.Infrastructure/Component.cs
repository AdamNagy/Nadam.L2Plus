using Microsoft.Extensions.DependencyInjection;

using GraduateNotes.DataAccess.Contract.Repositories;
using GraduateNotes.DataAccess.Repositories;
using GraduateNotes.DataAccess;

namespace GrduateNotes.DataAccess.Infrastructure
{
    public static class Component
    {
        public static IServiceCollection Register()
        {
            return new ServiceCollection()
                .AddScoped<INoteRepository, NoteRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddDbContext<GraduateNotesContext>();
        }
    }
}
