using Microsoft.EntityFrameworkCore;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.ProductR
{
    public class PriceRepository : IRepository<Price>
    {
        private readonly ApplicationDbContext _db;

        public PriceRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Price model)
        {
            await _db.Prices.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Price model)
        {
            _db.Prices.Remove(model);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<Price> Get()
        {
            return _db.Prices;
        }

        public async Task<Price> GetById(uint id)
        {
            return await _db.Prices
                            .Where(x => x.Price_ID == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<Price> Update(Price model)
        {
            _db.Prices.Update(model);
            await _db.SaveChangesAsync();
            return model;
        }
    }
}
