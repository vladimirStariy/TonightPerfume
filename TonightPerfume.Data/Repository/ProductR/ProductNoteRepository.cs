using Microsoft.EntityFrameworkCore;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.ProductR
{
    public class ProductNoteRepository : IRepository<ProductNotes>
    {
        private readonly ApplicationDbContext _db;

        public ProductNoteRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(ProductNotes model)
        {
            await _db.ProductNotes.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public Task Delete(ProductNotes model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductNotes> Get()
        {
            return _db.ProductNotes.Include(x => x.PerfumeNote);
        }

        public async Task<ProductNotes> GetById(uint id)
        {
            return await _db.ProductNotes.Where(x => x.ProductNote_ID == id).FirstOrDefaultAsync();
        }

        public Task<ProductNotes> Update(ProductNotes model)
        {
            throw new NotImplementedException();
        }
    }
}
