﻿using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Implementation;
using PersonalFinance.Repository.UnifOfWorkRepository;
using PersonalFinance.Service.General;
using PersonalFinance.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Implementation
{
    public class NoteService : GeneralService<Note>, INoteService
    {
        private readonly IGeneralRepository<Note> _repository;

        public NoteService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.GetRepository<Note>();
        }

        public async Task<Note> Update(int Id, Note note)
        {
            var obj = await _repository.Get(u => u.Id == Id);

            obj.Text = note.Text;
            obj.TransactionNoteList = note.TransactionNoteList;

            return await ((NoteRepository)_repository).Update(obj);
        }
    }
}
