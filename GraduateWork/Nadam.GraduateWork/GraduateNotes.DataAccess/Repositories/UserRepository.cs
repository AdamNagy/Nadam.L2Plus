﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GraduateNotes.DataAccess.Contract.Repositories;
using GraduateNotes.DataAccess.Contract.Models;

namespace GraduateNotes.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private GraduateNotesContext context;
        private DbSet<UserEntity> table;

        public UserRepository(GraduateNotesContext _context)
        {
            context = _context;
            table = context.Set<UserEntity>();

            context.Database.EnsureCreated();
        }

        public UserEntity FindUser(string email, string password)
        {
            return table.SingleOrDefault(p => p.Email == email && p.Password == password);
        }

        public UserEntity FindUser(string email)
        {
            return table.SingleOrDefault(p => p.Email == email);
        }
    }
}
