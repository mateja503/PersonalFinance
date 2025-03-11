using PersonalFinance.Domain.Models;
using PersonalFinance.Repository.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.Interface
{
    public interface INoteRepository : IGeneralRepository<Note>
    {
        public Task<Note> Update(Note note);

    }
}
