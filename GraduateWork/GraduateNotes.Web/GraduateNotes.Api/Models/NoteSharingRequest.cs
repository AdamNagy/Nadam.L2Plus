using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateNotes.API.Models
{
    public class NoteSharingRequest
    {
        public string partnerid { get; set; }
        public int noteid { get; set; }
    }
}
