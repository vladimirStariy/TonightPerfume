using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.OrderR
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Order model)
        {
            await _db.Orders.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public Task Delete(Order model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Get()
        {
            return _db.Orders;
        }

        public Task<Order> GetById(uint id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Update(Order model)
        {
            throw new NotImplementedException();
        }
    }
}
