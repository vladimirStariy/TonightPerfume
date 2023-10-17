using System.Security.Claims;
using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.UserVM;

namespace TonightPerfume.Service.Services.AccountServ
{
    public interface IAccountService
    {
        Task<IBaseResponce<IDictionary<string, string>>> Login(LoginByNumDto model);
        Task<IBaseResponce<string>> RegisterBySms(string phone);
        Task<IBaseResponce<IDictionary<string, string>>> RefreshToken(string token);
        Task<IBaseResponce<string>> Logout(string token);
    }
}
