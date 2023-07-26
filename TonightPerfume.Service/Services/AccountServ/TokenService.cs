using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;

namespace TonightPerfume.Service.Services.AccountServ
{
    public class TokenService : ITokenService
    {
        private readonly IRepository<RefreshToken> _tokenRepository;

        public TokenService(IRepository<RefreshToken> tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public Task<IBaseResponce<BaseUser>> ValidateAccessToken(string token)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponce<BaseUser>> ValidateRefreshToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
