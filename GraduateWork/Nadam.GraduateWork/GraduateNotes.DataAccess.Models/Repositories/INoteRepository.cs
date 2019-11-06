using GraduateNotes.DataAccess.Contracts.Models;
using System.Collections.Generic;

namespace GraduateNotes.DataAccess.Contract.Repositories
{
    public interface INoteRepository
    {
        IEnumerable<NoteEntity> GetNotesFor(string userId);
    }
}
