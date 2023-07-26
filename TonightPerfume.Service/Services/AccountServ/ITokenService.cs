using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;

namespace TonightPerfume.Service.Services.AccountServ
{
    public interface ITokenService
    {
        Task<IBaseResponce<BaseUser>> ValidateRefreshToken(string token);
        Task<IBaseResponce<BaseUser>> ValidateAccessToken(string token);
    }
}
