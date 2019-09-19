using Nadam.GraduateWork.CoreContract.Domain;
using System;
using System.Collections.Generic;

namespace Nadam.GraduateWork.CoreContract
{
    interface INotesRepository
    {
        IEnumerable<Note> GetNotes(Guid userId);
        Note UpdateNote(Note note);
        bool DeleteNote(Note note);
        Note CreateNote(Note note);
    }
}
