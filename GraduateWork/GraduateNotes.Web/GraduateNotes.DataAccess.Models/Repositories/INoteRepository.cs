using GraduateNotes.DataAccess.Contract.Models;
using System.Collections.Generic;

namespace GraduateNotes.DataAccess.Contract.Repositories
{
    public interface INoteRepository
    {
        IEnumerable<NoteEntity> GetNotesFor(int userId);
        NoteEntity GetById(int id);
        NoteEntity AddNew(NoteEntity note);
        NoteEntity Update(NoteEntity note);
        void Delete(int id);
    }
}
