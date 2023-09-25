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
            throw new NotImplementedException();
        }

        public Task<Category> GetById(uint id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Update(Category model)
        {
            throw new NotImplementedException();
        }
    }
}
