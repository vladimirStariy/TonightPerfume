using TonightPerfume.Domain.Models;
using TonightPerfume.Domain.Response;

namespace TonightPerfume.Service.Services.ProductServ.Interfaces
{
    public interface IAromaGroupService
    {
        Task<IBaseResponce<AromaGroup>> Create(AromaGroup model);
        Task<IBaseResponce<List<AromaGroup>>> Get();
        Task<IBaseResponce<List<AromaGroup>>> GetSomeGroups(int count);
    }
}
