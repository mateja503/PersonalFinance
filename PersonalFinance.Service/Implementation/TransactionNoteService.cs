using PersonalFinance.Domain.Models;
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
    public class TransactionNoteService : GeneralService<TransactionNotes>, ITransactionNoteService
    {
        private readonly IGeneralRepository<TransactionNotes> _repository;

        public TransactionNoteService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
            _repository = unitOfWork.GetRepository<TransactionNotes>();
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
