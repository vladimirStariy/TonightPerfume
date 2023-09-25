using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.DiscountR
{
    public class DiscountRepository : IRepository<Discount>
    {
        private readonly ApplicationDbContext _db;

        public DiscountRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Discount model)
        {
            await _db.Discounts.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public Task Delete(Discount model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Discount> Get()
        {
            return _db.Discounts;
        }

        public Task<Discount> GetById(uint id)
        {
            throw new NotImplementedException();
        }

        public Task<Discount> Update(Discount model)
        {
            throw new NotImplementedException();
        }
    }
}
