using System.Security.Claims;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models.User;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.UserVM;

namespace TonightPerfume.Service.Services.AccountServ
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<BaseUser> _userRepository;

        public AccountService(IRepository<BaseUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Response<ClaimsIdentity>> Login(LoginDto model)
        {
            throw new NotImplementedException();
        }
    }
}
