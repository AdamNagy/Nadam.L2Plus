using GraduateNotes.Service.Contract.Models;
using System.Collections.Generic;

namespace GraduateNotes.Service.Contract.Interfaces
{
    public interface INoteService
    {
        IEnumerable<Note> GetMyNotes(int userId);
        Note Create(Note newNote, int owner);
        Note Update(Note toUpdate);
        bool Delete(int id);
    }
}
