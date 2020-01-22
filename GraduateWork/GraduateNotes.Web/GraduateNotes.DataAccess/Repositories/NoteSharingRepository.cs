using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraduateNotes.DataAccess;
using GraduateNotes.DataAccess.Contract.Models;
using GraduateNotes.DataAccess.Contract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GraduateNotes.SqlServerDataAccess.Repositories
{
    public class NoteSharingRepository : INoteSharingRepository
    {
        private GraduateNotesContext context;
        private DbSet<NoteSharing> table;

        public NoteSharingRepository(GraduateNotesContext _context)
        {
            context = _context;
            table = context.Set<NoteSharing>();
        }

        public void Add(NoteSharing entity)
        {
            table.Add(entity);
            context.SaveChanges();
        }

        public IEnumerable<NoteSharing> Read(int partner)        
            => table.Where(item => item.SharedWithId == partner);
        
    }
}
