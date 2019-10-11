using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraduateNotes.Core.NotesDomain
{
    public interface IRepository<T>
    {
        T GetById(int id);
        T Update(T updated);
    }

    public interface INoteRepository : IRepository<Note>
    {        
        IEnumerable<Note> GetByOwner(string owner);
        bool Share(int noteId, string shareWith);
    }

    public class NoteRepositroy : INoteRepository
    {
        private static List<Note> table;
        private static List<NoteShare> noteShares;

        static NoteRepositroy()
        {
            table = new List<Note>(10);
            noteShares = new List<NoteShare>();

            if( table.Count == 0 )
            {
                table.Add(new Note()
                {
                    Id = 1,
                    Owner = "number-sequ-1",
                    Type = NoteType.text,
                    Url = "",
                    Title = "Friday todos:",
                    Text = "Demo L2plus app for others and pray to god"
                });

                table.Add(new Note()
                {
                    Id = 2,
                    Owner = "number-sequ-1",
                    Type = NoteType.text,
                    Url = "",
                    Title = "Next week todos:",
                    Text = "Finish Betsson ticket, make the PR mergeable"
                });
            }
        }

        public Note GetById(int id)
        {
            return table.Single(p => p.Id == id);
        }

        public IEnumerable<Note> GetByOwner(string owner)
        {
            return table.Where(p => p.Owner == owner);
        }

        public bool Share(int noteId, string shareWith)
        {
            var owner = GetById(noteId)?.Owner;

            if(owner != null)
            {
                noteShares.Add(new NoteShare(owner, shareWith));
                return true;
            }
                
            return false;
        }

        public Note Update(Note updated)
        {
            var note = GetById(updated.Id);
            

            if (note == null)
                return null;

            var idx = table.IndexOf(note);
            table[idx] = updated;

            return table[idx];
        }
    }
}
