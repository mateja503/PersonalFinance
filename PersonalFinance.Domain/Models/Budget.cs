using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Models
{
    public class Budget
    {
        public int Id { get; set; }

        public DateTime dateTime { get; set; }

        public double? budgetAmount { get; set; }

    }
}
