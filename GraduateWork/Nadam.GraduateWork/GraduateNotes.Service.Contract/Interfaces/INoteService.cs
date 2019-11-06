using GraduateNotes.Service.Contract.Model;
using System.Collections.Generic;

namespace GraduateNotes.Service.Contract.Interfaces
{
    public interface INoteService
    {
        IEnumerable<Note> GetMyNotes(string userId);
    }
}
