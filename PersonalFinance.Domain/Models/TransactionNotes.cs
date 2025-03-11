using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Models
{
    class TransactionNotes
    {

        public int? Id { get; set; }
        public Transaction? Transaction { get; set; }
        public int? TransactionId { get; set; }

        public Note? Note { get; set; }

        public int? NoteId { get; set; }

    }
}
