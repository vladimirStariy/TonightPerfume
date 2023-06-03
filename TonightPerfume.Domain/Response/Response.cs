using TonightPerfume.Domain.Enum;

namespace TonightPerfume.Domain.Response
{
    public interface IBaseResponce<T>
    {
        string Description { get; }
        StatusCode StatusCode { get; }
        T Result { get; }
    }

    public class Response<T> : IBaseResponce<T>
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }
        public T Result { get; set; }
    }
}
