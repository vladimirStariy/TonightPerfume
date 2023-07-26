using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.UserVM;

namespace TonightPerfume.Service.Services.UserServ
{
    public interface IUserService
    {
        Task<IBaseResponce<BaseUser>> GetById(uint id);
        Task<IBaseResponce<List<BaseUser>>> Get();
    }
}
