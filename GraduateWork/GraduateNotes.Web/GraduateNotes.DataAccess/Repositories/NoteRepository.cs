using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GraduateNotes.DataAccess.Contract.Repositories;
using GraduateNotes.DataAccess.Contract.Models;

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

        public NoteEntity AddNew(NoteEntity note)
        {
            table.Add(note);
            context.SaveChanges();
            return GetById(note.Id);
        }

        public IEnumerable<NoteEntity> GetNotesFor(int userId)
        {
            return table.Where(p => p.OwnerId == userId);
        }

        public NoteEntity GetById(int id)
        {
            return table.SingleOrDefault(p => p.Id == id);
        }
    }
}
