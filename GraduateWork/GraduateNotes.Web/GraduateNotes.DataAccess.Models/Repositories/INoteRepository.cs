using GraduateNotes.DataAccess.Contract.Models;
using System.Collections.Generic;

namespace GraduateNotes.DataAccess.Contract.Repositories
{
    public interface INoteRepository
    {
        IEnumerable<NoteEntity> GetNotesFor(int userId);
        NoteEntity AddNew(NoteEntity note);
    }
}
