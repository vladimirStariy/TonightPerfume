using Microsoft.EntityFrameworkCore;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.ProductR
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Category model)
        {
            await _db.Categories.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public Task Delete(Category model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> Get()
        {
            return _db.Categories;
        }

        public async Task<Category> GetById(uint id)
        {
            return await _db.Categories.Where(x => x.Category_ID == id).FirstOrDefaultAsync();
        }

        public Task<Category> Update(Category model)
        {
            throw new NotImplementedException();
        }
    }
}
