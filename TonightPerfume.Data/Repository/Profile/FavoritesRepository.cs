using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.Profile
{
    public class FavoritesRepository : IRepository<Favorite>
    {
        private readonly ApplicationDbContext _db;

        public FavoritesRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Favorite model)
        {
            await _db.Favorites.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Favorite model)
        {
            _db.Favorites.Remove(model);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<Favorite> Get()
        {
            return _db.Favorites;
        }

        public Task<Favorite> GetById(uint id)
        {
            throw new NotImplementedException();
        }

        public Task<Favorite> Update(Favorite model)
        {
            throw new NotImplementedException();
        }
    }
}
