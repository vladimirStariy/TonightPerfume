using TonightPerfume.Domain.Response;
using TonightPerfume.Domain.Viewmodels.Filter;

namespace TonightPerfume.Service.Services.FilterSrv
{
    public interface IFilterService
    {
        Task<IBaseResponce<FilterDto>> Get(int count);
    }
}
