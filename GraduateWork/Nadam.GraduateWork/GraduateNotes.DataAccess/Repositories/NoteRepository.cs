﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GraduateNotes.DataAccess.Contract.Repositories;
using GraduateNotes.DataAccess.Contracts.Models;

namespace GraduateNotes.DataAccess.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private GraduateNotesContext context;
        private DbSet<NoteEntity> table;

        public NoteRepository(GraduateNotesContext _context)
        {
            context = _context;
            table = context.Set<NoteEntity>();
        }

        public IEnumerable<NoteEntity> GetNotesFor(string userId)
        {
            return table.Where(p => p.Owner == userId);
        }
    }
}