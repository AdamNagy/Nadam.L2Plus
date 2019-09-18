using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadam.GraduateWork.CoreContract.Domain
{
    public class Note
    {
        public readonly int NoteId;
        public string Title { get; set; }
        public string Text { get; set; }

        public Note(int id)
        {
            NoteId = id;
        }
    }
}
