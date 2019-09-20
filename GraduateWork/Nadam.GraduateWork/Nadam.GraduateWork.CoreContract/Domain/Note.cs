using System;
using System.Collections;
using System.Collections.Generic;

namespace Nadam.GraduateWork.CoreContract.Domain
{
    public struct Note
    {
        public int NoteId { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }

        /// <summary>
        /// Account id, the person who created the actual note
        /// </summary>
        public Guid Owner { get; set; }

        /// <summary>
        /// string used in the url generated from title
        /// </summary>
        public string Slug { get; private set; }

        /// <summary>
        /// Number of the tab the current note is located on.
        /// </summary>
        public int TabNumber { get; private set; }

        /// <summary>
        /// Position on the tab, added in x:y format using real numbers: 2.3 -> (x:2 ; y:3)
        /// </summary>
        public double Coordinates { get; private set; }

        public Note(
            int noteId,
            string title,
            string text,
            Guid owner,
            string slug,
            int tabNum,
            double position)
        {
            NoteId = noteId;
            Title = title;
            Text = text;
            Owner = owner;
            Slug = slug;
            TabNumber = tabNum;
            Coordinates = position;
        }
    }
}
