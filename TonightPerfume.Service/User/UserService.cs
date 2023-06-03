using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models.User;

namespace TonightPerfume.Service.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<BaseUser> _userRepository;

        public UserService(IRepository<BaseUser> userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
