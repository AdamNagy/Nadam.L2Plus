using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GraduateNotes.Service.Contract.Interfaces;
using GraduateNotes.Service.Contract.Models;

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
        public bool Delete(int id)
        {
            service.Delete(id);
            return true;
        }

        [HttpPost]
        [Route("patch/{id}")]
        public Note Update([FromBody]Note note)
        {
            var updated = service.Update(note);
            return updated;
        }

        //[HttpGet]
        //[Route("get/shareablelink/{id}")]
        //public IEnumerable<Note> GetShareableLinkFor([FromRoute]int id)
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpPost]
        //[Route("share")]
        //public string Share(int noteId, string shareWith)
        //{
        //    service.Share(noteId, shareWith);
        //    return "All good";
        //}
    }
}