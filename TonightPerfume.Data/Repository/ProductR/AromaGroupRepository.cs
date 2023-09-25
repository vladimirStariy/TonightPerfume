using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.ProductR
{
    public class AromaGroupRepository : IRepository<AromaGroup>
    {
        private readonly ApplicationDbContext _db;

        public AromaGroupRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(AromaGroup model)
        {
            await _db.AromaGroups.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public Task Delete(AromaGroup model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AromaGroup> Get()
        {
            return _db.AromaGroups;
        }

        public Task<AromaGroup> GetById(uint id)
        {
            throw new NotImplementedException();
        }

        public Task<AromaGroup> Update(AromaGroup model)
        {
            throw new NotImplementedException();
        }
    }
}
