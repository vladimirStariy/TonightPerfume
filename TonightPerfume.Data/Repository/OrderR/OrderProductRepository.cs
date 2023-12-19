using Microsoft.EntityFrameworkCore;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.OrderR
{
    public class OrderProductRepository : IRepository<OrderProduct>
    {
        private readonly ApplicationDbContext _db;

        public OrderProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(OrderProduct model)
        {
            await _db.OrderProducts.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public Task Delete(OrderProduct model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderProduct> Get()
        {
            return _db.OrderProducts.Include(x => x.Price).Include(x => x.Order);
        }

        public Task<OrderProduct> GetById(uint id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderProduct> Update(OrderProduct model)
        {
            throw new NotImplementedException();
        }
    }
}
