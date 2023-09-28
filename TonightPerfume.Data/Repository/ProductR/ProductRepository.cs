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

        public IEnumerable<Product> Get()
        {
            return _db.Products
                      .Include(x => x.Brand)
                      .Include(x => x.PerfumeNotes);
        }

        public async Task<Product> GetById(uint id)
        {
            return await _db.Products
                            .Where(x => x.Product_ID == id)
                            .Include(x => x.PerfumeNotes)
                            .Include(x => x.Category)
                            .Include(x => x.Brand)
                            .FirstOrDefaultAsync();
        }

        public async Task<Product> Update(Product model)
        {
            _db.Products.Update(model);
            await _db.SaveChangesAsync();
            return model;
        }
    }
}
