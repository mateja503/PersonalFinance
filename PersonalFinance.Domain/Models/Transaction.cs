using PersonalFinance.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Models
{
    public class Transaction
    {
        public int Id { get; set; }  

        public DateTime dateTime { get; set; }

        public double? amount { get; set; }

        public TransactionType TransactionType { get; set; }
        public Category? CategoryTransaction { get; set; }

        public int? CategoryTransactionId { get; set; }


        public List<Note> TransactionNoteList { get; set; }


    }
}
