using Microsoft.EntityFrameworkCore;
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

        public async Task Delete(Adress model)
        {
            _db.Adresses.Remove(model);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<Adress> Get()
        {
            return _db.Adresses;
        }

        public async Task<Adress> GetById(uint id)
        {
            return await _db.Adresses.Where(x => x.Adress_ID == id).Include(x => x.Profile).FirstOrDefaultAsync();
        }

        public Task<Adress> Update(Adress model)
        {
            throw new NotImplementedException();
        }
    }
}
