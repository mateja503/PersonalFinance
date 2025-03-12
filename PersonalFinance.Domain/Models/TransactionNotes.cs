using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Models
{
    public class TransactionNotes
    {

        public int? Id { get; set; }
        public virtual Transaction? Transaction { get; set; }
        public int? TransactionId { get; set; }

        public virtual Note? Note { get; set; }

        public int? NoteId { get; set; } 

        
    }
}
