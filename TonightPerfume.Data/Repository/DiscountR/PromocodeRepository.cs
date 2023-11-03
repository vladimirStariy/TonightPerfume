using Microsoft.EntityFrameworkCore;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.DiscountR
{
    public class PromocodeRepository : IRepository<Promocode>
    {
        private readonly ApplicationDbContext _db;

        public PromocodeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Promocode model)
        {
            await _db.Promocodes.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Promocode model)
        {
            _db.Promocodes.Remove(model);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<Promocode> Get()
        {
            return _db.Promocodes;
        }

        public async Task<Promocode> GetById(uint id)
        {
            return await _db.Promocodes
                            .Where(x => x.Promocode_ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<Promocode> Update(Promocode model)
        {
            throw new NotImplementedException();
        }
    }
}
