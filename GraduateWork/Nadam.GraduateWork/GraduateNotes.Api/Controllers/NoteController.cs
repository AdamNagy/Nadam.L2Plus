using System;
using System.Collections.Generic;
using GraduateNotes.Core;
using GraduateNotes.Core.NotesDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateNotes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private INoteRepository repository;

        public NoteController(INoteRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<Note> GetMine()
        {
            var userId = HttpContext.User.Identity.Name;
            var myNotes = repository.GetByOwner(userId);
            return myNotes;
        }

        [HttpPost]
        [Route("share")]
        public string Share(int noteId, string shareWith)
        {
            repository.Share(noteId, shareWith);
            return "All good";
        }

        [HttpPost]
        [Route("update")]
        public Note Update([FromBody]Note note)
        {
            var updated = repository.Update(note);
            return updated;
        }
    }
}