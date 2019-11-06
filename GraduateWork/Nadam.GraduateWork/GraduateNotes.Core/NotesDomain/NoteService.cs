using System.Collections.Generic;
using System.Linq;

using GraduateNotes.DataAccess.Contract.Repositories;
using GraduateNotes.DataAccess.Contracts.Models;
using GraduateNotes.Service.Contract.Interfaces;
using GraduateNotes.Service.Contract.Model;

namespace GraduateNotes.Service.NotesDomain
{
    public class NoteService : INoteService
    {
        private INoteRepository repository;

        public NoteService(INoteRepository _repository)
        {
            repository = _repository;
        }

        public IEnumerable<Note> GetMyNotes(string userId)
        {
            var entities = repository.GetNotesFor(userId);
            return entities.Select(Map);
        }

        private Note Map(NoteEntity entity)
        {
            return new Note()
            {
                Owner = entity.Owner,
                Url = entity.Location
            };
        }
    }
}
