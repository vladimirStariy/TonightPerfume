using System.Security.Claims;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.User;

namespace TonightPerfume.Service.User
{
    public interface IAccountService
    {
        Task<Response<ClaimsIdentity>> Login(LoginViewmodel model);
    }
}
