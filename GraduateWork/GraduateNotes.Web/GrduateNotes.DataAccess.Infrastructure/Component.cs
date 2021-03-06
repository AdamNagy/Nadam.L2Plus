﻿using Microsoft.Extensions.DependencyInjection;

using GraduateNotes.DataAccess.Contract.Repositories;
using GraduateNotes.DataAccess.Repositories;
using GraduateNotes.DataAccess;
using GraduateNotes.SqlServerDataAccess.Repositories;

namespace GrduateNotes.DataAccess.Infrastructure
{
    public static class Component
    {
        public static IServiceCollection Register(IServiceCollection collection)
        {
            return collection
                .AddScoped<INoteRepository, NoteRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<INoteSharingRepository, NoteSharingRepository>()
                .AddDbContext<GraduateNotesContext>();
        }
    }
}
