using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.Data;
using PersonalFinance.Repository.General;
using PersonalFinance.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.Implementation
{
    public class TransactionNotesRepository : GeneralRepository<TransactionNotes>, ITransactionNotesRepository
    {
        private readonly ApplicationDbContext _db;

        public TransactionNotesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<TransactionNotes> Update(TransactionNotes transactionNotes)
        {
            _db.TransactionNotes.Update(transactionNotes);
            await _db.SaveChangesAsync();
            return transactionNotes;
        }
    }
}
