using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.Data;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Implementation;
using PersonalFinance.Repository.Interface;
using PersonalFinance.Service.General;
using PersonalFinance.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Implementation
{
    public class TransactionNoteService : GeneralService<TransactionNotes,ITransactionNotesRepository>, ITransactionNoteService
    {
        private readonly ITransactionNotesRepository _repository;

        public TransactionNoteService(ITransactionNotesRepository repository,ApplicationDbContext db) : base(repository)
        {
            _repository = new TransactionNotesRepository(db);
        }

        public async Task<TransactionNotes> Update(int Id, TransactionNotes transactionNotes)
        {
            var obj = await _repository.Get(u => u.Id == Id);

            obj.NoteId = transactionNotes.NoteId;
            obj.TransactionId = transactionNotes.TransactionId;

            return await ((TransactionNotesRepository)_repository).Update(obj);
        }
    }
}
