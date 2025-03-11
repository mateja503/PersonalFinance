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
    public class TransactionRepository : GeneralRepository<Transaction>, ITransactionRepository
    {
        private readonly ApplicationDbContext _db;
        public TransactionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Transaction> Update(Transaction transaction)
        {
            _db.Transactions.Update(transaction);
            await _db.SaveChangesAsync();
            return transaction;
        }
    }
}
