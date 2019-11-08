using System;
using System.Collections.Generic;
using System.Text;
using GraduateNotes.Service.Contract.Models;

namespace GraduateNotes.Service.Contract.Interfaces
{
    public interface IStorageService
    {
        File GetFile(string location, string name);
    }
}
