using System;
using System.Collections.Generic;
using System.Text;

namespace GraduateNotes.Core.NotesDomain
{
    struct NoteShare
    {
        string owner;
        string sharedWith;

        public NoteShare(string _owner, string other)
        {
            owner = _owner;
            sharedWith = other;
        }
    }
}
