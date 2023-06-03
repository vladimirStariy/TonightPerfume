using System.Security.Claims;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models.User;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.User;

namespace TonightPerfume.Service.User
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<BaseUser> _userRepository;

        public AccountService(IRepository<BaseUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Response<ClaimsIdentity>> Login(LoginViewmodel model)
        {
            throw new NotImplementedException();
        }
    }
}
