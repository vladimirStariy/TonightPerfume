using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.ProductR
{
    public class AtomizerColorRepository : IRepository<AtomizerColor>
    {
        private readonly ApplicationDbContext _db;

        public AtomizerColorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task Create(AtomizerColor model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(AtomizerColor model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AtomizerColor> Get()
        {
            return _db.AtomizerColors;
        }

        public Task<AtomizerColor> GetById(uint id)
        {
            throw new NotImplementedException();
        }

        public Task<AtomizerColor> Update(AtomizerColor model)
        {
            throw new NotImplementedException();
        }
    }
}
