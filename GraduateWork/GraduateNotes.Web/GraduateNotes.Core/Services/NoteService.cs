using System;
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
        private INoteSharingRepository noteSharingRepo;
        private IUserRepository userRepository;

        public NoteService(
            INoteRepository _repository,
            INoteSharingRepository _noteSharingRepo,
            IUserRepository _userRepository)
        {
            repository = _repository;
            noteSharingRepo = _noteSharingRepo;
            userRepository = _userRepository;
        }

        public Note Create(Note newNote, int owner)
        {
            var noteEntity = Map(newNote, owner);
            noteEntity = repository.AddNew(noteEntity);
            return Map(noteEntity);
        }

        public bool Delete(int noteId, int userId)
        {
            repository.Delete(noteId);
            return true;
        }

        public IEnumerable<Note> GetMyNotes(int userId)
        {
            var entities = repository.GetNotesFor(userId).ToList();
            var sharedWithMe = noteSharingRepo.Read(userId);

            foreach (var item in sharedWithMe)            
                entities.Add(repository.GetById(item.NoteId));            

            return entities.Select(Map);
        }

        public void ShareNote(int owner, string partner, int noteId)
        {
            var partnerAcc = userRepository.Read(partner);

            if(partnerAcc == null)            
                throw new ArgumentException();
            
            noteSharingRepo.Add(new NoteSharing()
            {
                NoteId = noteId,
                OwnerId = owner,
                SharedWithId = partnerAcc.Id
            });
        }

        public Note Update(Note toUpdate, int userId)
        {
            var entity = Map(toUpdate, userId);
            return Map(repository.Update(entity));
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
                Id = businessModel.Noteid,
                Content = businessModel.Content,
                Type = (int)businessModel.Type,
                OwnerId = userId                
            };
        }
    }
}
