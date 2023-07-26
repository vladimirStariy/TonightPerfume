using Microsoft.EntityFrameworkCore;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.ProductR
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Product model)
        {
            await _db.Products.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Product model)
        {
            _db.Products.Remove(model);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Product> Get()
        {
            return _db.Products;
        }

        public async Task<Product> GetById(uint id)
        {
            return await _db.Products.Where(x => x.Product_ID == id).FirstOrDefaultAsync();
        }

        public async Task<Product> Update(Product model)
        {
            _db.Products.Update(model);
            await _db.SaveChangesAsync();
            return model;
        }
    }
}
