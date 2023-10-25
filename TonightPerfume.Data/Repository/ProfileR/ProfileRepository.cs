using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.ProfileR
{
    public class ProfileRepository : IRepository<Profile>
    {
        private readonly ApplicationDbContext _db;

        public ProfileRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Profile model)
        {
            await _db.Profiles.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public Task Delete(Profile model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Profile> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Profile> GetById(uint id)
        {
            throw new NotImplementedException();
        }

        public Task<Profile> Update(Profile model)
        {
            throw new NotImplementedException();
        }
    }
}
