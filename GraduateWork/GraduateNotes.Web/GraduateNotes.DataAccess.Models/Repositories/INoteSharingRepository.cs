using GraduateNotes.DataAccess.Contract.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduateNotes.DataAccess.Contract.Repositories
{
    public interface INoteSharingRepository
    {
        void Add(NoteSharing entity);
        IEnumerable<NoteSharing> Read(int partner);
    }
}
