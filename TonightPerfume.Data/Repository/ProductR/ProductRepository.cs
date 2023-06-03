using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models.Product;

namespace TonightPerfume.Data.Repository.ProductR
{
    public class ProductRepository : IRepository<Product>
    {
        public Task Create(Product model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Product model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(uint id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(Product model)
        {
            throw new NotImplementedException();
        }
    }
}
