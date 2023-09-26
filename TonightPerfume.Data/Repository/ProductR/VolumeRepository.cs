using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.ProductR
{
    public class VolumeRepository : IRepository<Volume>
    {
        private readonly ApplicationDbContext _db;

        public VolumeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Volume model)
        {
            await _db.Volumes.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public Task Delete(Volume model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Volume> Get()
        {
            return _db.Volumes;
        }

        public Task<Volume> GetById(uint id)
        {
            throw new NotImplementedException();
        }

        public Task<Volume> Update(Volume model)
        {
            throw new NotImplementedException();
        }
    }
}
