using Microsoft.EntityFrameworkCore;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.User
{
    public class TokenRepository : ITokenRepository<RefreshToken>
    {
        private readonly ApplicationDbContext _db;

        public TokenRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(RefreshToken model)
        {
            await _db.Tokens.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(RefreshToken model)
        {
            _db.Tokens.Remove(model);
            await _db.SaveChangesAsync();
        }

        public async Task<RefreshToken> GetById(string token)
        {
            return await _db.Tokens.Where(x => x.Token == token).FirstOrDefaultAsync();
        }

        public async Task<RefreshToken> GetByUserId(uint id)
        {
            return await _db.Tokens.Where(x => x.User_ID == id).FirstOrDefaultAsync();
        }

        public async Task<RefreshToken> Update(RefreshToken oldToken, RefreshToken newToken)
        {
            _db.Tokens.Remove(oldToken);
            await _db.Tokens.AddAsync(newToken);
            await _db.SaveChangesAsync();
            return newToken;
        }
    }
}
