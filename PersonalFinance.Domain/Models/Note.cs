using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Models
{
    public class Note
    {
        public int Id { get; set; }

        public string? Text { get; set; }

        public List<Transaction?> NoteTransactionList { get; set; }
    }
}
