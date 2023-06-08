using System.Security.Claims;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.UserVM;

namespace TonightPerfume.Service.Services.AccountServ
{
    public interface IAccountService
    {
        Task<Response<ClaimsIdentity>> Login(LoginViewmodel model);
    }
}
