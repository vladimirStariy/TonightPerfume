namespace TonightPerfume.Data.Repository.BaseRepository
{
    public interface ITokenRepository<T>
    {
        Task Create(T model);
        Task<T> Update(T oldToken, T newToken);
        Task Delete(T model);
        Task<T> GetByUserId(uint id);
        Task<T> GetById(string token);
    }
}
