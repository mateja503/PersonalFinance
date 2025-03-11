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
    public class NoteRepository : GeneralRepository<Note>, INoteRepository
    {
        private readonly ApplicationDbContext _db;
        public NoteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Note> Update(Note note)
        {
            _db.Notes.Update(note);
            await _db.SaveChangesAsync();
            return note;
        }
    }
}
