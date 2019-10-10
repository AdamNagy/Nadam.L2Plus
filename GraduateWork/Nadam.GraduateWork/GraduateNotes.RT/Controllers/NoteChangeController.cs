using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateNotes.RT.Controllers
{
    [Route("notechange")]
    [ApiController]
    public class NoteChangeController : ControllerBase
    {
        [HttpGet]
        [Route("simple")]
        public string simple()
        {
            return "hello from rt";
        }

        [HttpPost]
        [Route("")]
        public void TriggerRealtime(int userId, int noteId)
        {

        }
    }
}