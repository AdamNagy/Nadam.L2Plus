﻿using GraduateNotes.Service.Contract.Models;
using System.Collections.Generic;

namespace GraduateNotes.Service.Contract.Interfaces
{
    public interface INoteService
    {
        IEnumerable<Note> GetMyNotes(int userId);
    }
}
