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
        public IEnumerable<Note> GetMyNotes()
        {
            var userId = HttpContext.User.Identity.Name;
            var myNotes = repository.GetByOwner(userId);
            return myNotes;
        }

        [HttpPost]
        [Route("create")]
        public Note Create([FromBody]Note newNote)
        {
            newNote.Owner = HttpContext.User.Identity.Name;
            var createdNote = repository.Create(newNote);
            return createdNote;
        }

        [HttpGet]
        [Route("delete/{id}")]
        public bool Delete(int id)
        {
            repository.Delete(id);
            return true;
        }

        [HttpPost]
        [Route("update")]
        public Note Update([FromBody]Note note)
        {
            var updated = repository.Update(note);
            return updated;
        }

        [HttpGet]
        [Route("get/shareablelink/{id}")]
        public IEnumerable<Note> GetShareableLinkFor([FromRoute]int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("share")]
        public string Share(int noteId, string shareWith)
        {
            repository.Share(noteId, shareWith);
            return "All good";
        }
    }
}