using PersonalFinance.Domain.Models;
using PersonalFinance.Service.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Interface
{
    public interface ITransactionNoteService: IGeneralService<TransactionNotes>
    {
        public Task<TransactionNotes> Update(int Id, TransactionNotes transactionNotes);
        //public Task<TransactionNotes> GetTransaction(int Id);

         
    }
}
