using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateNotes.RT.Realtime
{
    public class NotesHub : Hub
    {
        public async Task NoteUpdated(int userId, int noteId)
        {
            await Clients.All.SendAsync("noteupdated", userId, noteId);
        }
    }
}
