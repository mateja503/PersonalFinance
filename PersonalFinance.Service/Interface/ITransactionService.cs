using PersonalFinance.Domain.Models;
using PersonalFinance.Service.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Interface
{
    public interface ITransactionService : IGeneralService<Transaction>
    {
        public Task<Transaction> Update(int Id, Transaction transaction);
    }
}
