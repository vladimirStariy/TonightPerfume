using Microsoft.EntityFrameworkCore;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.ProductR
{
    public class BrandRepository : IRepository<Brand>
    {
        private readonly ApplicationDbContext _db;

        public BrandRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Brand model)
        {
            await _db.Brands.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public Task Delete(Brand model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brand> Get()
        {
            return _db.Brands;
        }

        public async Task<Brand> GetById(uint id)
        {
            return await _db.Brands.Where(x => x.Brand_ID == id).FirstOrDefaultAsync();
        }

        public Task<Brand> Update(Brand model)
        {
            throw new NotImplementedException();
        }
    }
}
