using Microsoft.EntityFrameworkCore;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.ProductR
{
    public class PerfumeNoteRepository : IRepository<PerfumeNote>
    {
        private readonly ApplicationDbContext _db;

        public PerfumeNoteRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(PerfumeNote model)
        {
            await _db.PerfumeNotes.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public Task Delete(PerfumeNote model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PerfumeNote> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<PerfumeNote> GetById(uint id)
        {
            return await _db.PerfumeNotes.Where(x => x.Note_ID == id).FirstOrDefaultAsync();
        }

        public Task<PerfumeNote> Update(PerfumeNote model)
        {
            throw new NotImplementedException();
        }
    }
}
