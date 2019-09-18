using Nadam.GraduateWork.CoreContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadam.GraduateWork.Core
{
    public class NotesService : INotesService
    {
        public string Echo(string echo)
        {
            return echo;
        }
    }
}
