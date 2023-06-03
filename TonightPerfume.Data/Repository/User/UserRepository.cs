using Microsoft.EntityFrameworkCore;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models.User;

namespace TonightPerfume.Data.Repository.User
{
    public class UserRepository : IRepository<BaseUser>
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(BaseUser model)
        {
            await _db.Users.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public Task<BaseUser> Update(BaseUser model)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(BaseUser model)
        {
            _db.Users.Remove(model);
            await _db.SaveChangesAsync();
        }

        public IQueryable<BaseUser> Get()
        {
            return _db.Users;
        }

        public Task<BaseUser> GetById(uint id)
        {
            return _db.Users.Where(x => x.User_ID == id).FirstOrDefaultAsync();
        }
    }
}
