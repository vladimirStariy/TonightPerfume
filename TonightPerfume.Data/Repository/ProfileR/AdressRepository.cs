using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.ProfileR
{
    public class AdressRepository : IRepository<Adress>
    {
        private readonly ApplicationDbContext _db;

        public AdressRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Adress model)
        {
            await _db.Adresses.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public Task Delete(Adress model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Adress> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Adress> GetById(uint id)
        {
            throw new NotImplementedException();
        }

        public Task<Adress> Update(Adress model)
        {
            throw new NotImplementedException();
        }
    }
}
