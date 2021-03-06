﻿using GraduateNotes.Service.AccountDomain;
using GraduateNotes.Service.Contract.Interfaces;
using GraduateNotes.Service.NotesDomain;

using Microsoft.Extensions.DependencyInjection;

namespace GraduateNotes.Service.Infrastructure
{
    public class Component
    {
        public static IServiceCollection Register(IServiceCollection collection)
        {
            GrduateNotes.DataAccess.Infrastructure.Component.Register(collection);

            return collection
                .AddScoped<INoteService, NoteService>()
                .AddScoped<IUserService, UserService>();
        }
    }
}
