using System.Collections.Generic;
using System.Linq;

using GraduateNotes.DataAccess.Contract.Repositories;
using GraduateNotes.DataAccess.Contract.Models;
using GraduateNotes.Service.Contract.Interfaces;
using GraduateNotes.Service.Contract.Models;

namespace GraduateNotes.Service.NotesDomain
{
    public class NoteService : INoteService
    {
        private INoteRepository repository;

        public NoteService(INoteRepository _repository)
        {
            repository = _repository;
        }

        public Note Create(Note newNote, int owner)
        {
            var noteEntity = Map(newNote, owner);
            noteEntity = repository.AddNew(noteEntity);
            return Map(noteEntity);
        }

        public bool Delete(int id)
        {
            repository.
            throw new System.NotImplementedException();
        }

        public IEnumerable<Note> GetMyNotes(int userId)
        {
            var entities = repository.GetNotesFor(userId);
            return entities.Select(Map);
        }

        public Note Update(Note toUpdate)
        {
            throw new System.NotImplementedException();
        }

        private Note Map(NoteEntity entity)
        {
            return new Note(entity.Id)
            {
                Content = entity.Content,
                Type = (NoteType)entity.Type,
                Created = entity.Created
            };
        }

        private NoteEntity Map(Note businessModel, int userId)
        {
            return new NoteEntity()
            {
                Content = businessModel.Content,
                Type = (int)businessModel.Type,
                OwnerId = userId
            };
        }
    }
}
