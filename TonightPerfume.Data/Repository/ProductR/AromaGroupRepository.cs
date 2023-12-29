using Microsoft.EntityFrameworkCore;
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

        public async Task<AromaGroup> GetById(uint id)
        {
            return await _db.AromaGroups.Where(x => x.AromaGroup_ID == id).FirstOrDefaultAsync();
        }

        public Task<AromaGroup> Update(AromaGroup model)
        {
            throw new NotImplementedException();
        }
    }
}
