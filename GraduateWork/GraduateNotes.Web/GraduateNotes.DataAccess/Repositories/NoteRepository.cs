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
            => table.Where(p => p.OwnerId == userId);        

        public NoteEntity GetById(int id)        
            => table.SingleOrDefault(p => p.Id == id);        

        public NoteEntity Update(NoteEntity note)
        {
            var toUpdateNote = GetById(note.Id);
            if( toUpdateNote == null )            
                throw new ArgumentException($"given note does not exist: {note.Id} {note.Owner}");

            toUpdateNote.Content = note.Content;
            context.SaveChanges();
            return toUpdateNote;
        }

        public void Delete(int id)
        {
            var toDeleteNote = GetById(id);
            if (toDeleteNote == null)
                throw new ArgumentException($"given note does not exist: {toDeleteNote.Id} {toDeleteNote.Owner}");

            table.Remove(toDeleteNote);
            context.SaveChanges();
        }

        public void ShareNote(int owner, int partner, int noteId)
        {
            throw new NotImplementedException();
        }
    }
}
