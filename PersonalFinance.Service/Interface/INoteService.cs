﻿using PersonalFinance.Domain.Models;
using PersonalFinance.Service.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Interface
{
    public interface INoteService : IGeneralService<Note>
    {
        public Task<Note> Update(int Id, Note note);
    }
}
