using TonightPerfume.Domain.Models.User;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.UserVM;

namespace TonightPerfume.Service.Services.UserServ
{
    public interface IUserService
    {
        Task<IBaseResponce<BaseUser>> Register(RegisterDto model);
        Task<IBaseResponce<BaseUser>> GetById(uint id);
        Task<IBaseResponce<List<BaseUser>>> Get();
        Task<IBaseResponce<string>> Login(LoginDto model);
    }
}
