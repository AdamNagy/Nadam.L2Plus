using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GraduateNotes.Service.Contract.Interfaces;
using GraduateNotes.Service.Contract.Models;
using GraduateNotes.API.Models;

namespace GraduateNotes.API.Controllers
{
    [Route("api/note")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private INoteService service;

        public NoteController(INoteService _service)
        {
            service = _service;
        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<Note> GetMyNotes()
        {
            var userId = HttpContext.User.Identity.Name;
            var myNotes = service.GetMyNotes(Convert.ToInt32(userId));
            return myNotes;
        }

        [HttpPost]
        [Route("post")]
        public IActionResult Create([FromBody]Note newNote)
        {
            int userId = -1;
            int.TryParse(HttpContext.User.Identity.Name, out userId);
            var createdNote = service.Create(newNote, userId);
            return Ok(createdNote);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            int userId = -1;
            int.TryParse(HttpContext.User.Identity.Name, out userId);
            service.Delete(id, userId);
            return Ok(true);
        }

        [HttpPatch]
        [Route("patch")]
        public IActionResult Update([FromBody]Note note)
        {
            if (String.IsNullOrEmpty(note.Content))
                return Ok();

            int userId = -1;
            int.TryParse(HttpContext.User.Identity.Name, out userId);
            var updated = service.Update(note, userId);
            return Ok(updated);
        }

        [HttpPost]
        [Route("share-note")]
        public string Share([FromBody]NoteSharingRequest request)
        {
            int userId = -1;
            int.TryParse(HttpContext.User.Identity.Name, out userId);
            service.ShareNote(userId, request.partnerid, request.noteid);
            return "All good";
        }
    }
}