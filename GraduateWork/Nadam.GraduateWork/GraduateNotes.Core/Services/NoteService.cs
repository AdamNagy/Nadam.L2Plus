﻿using System.Collections.Generic;
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

        public IEnumerable<Note> GetMyNotes(int userId)
        {
            var entities = repository.GetNotesFor(userId);
            return entities.Select(Map);
        }

        private Note Map(NoteEntity entity)
        {
            return new Note()
            {
                Owner = entity.Owner.Id,
                // Url = entity.FileTitle
            };
        }
    }
}
