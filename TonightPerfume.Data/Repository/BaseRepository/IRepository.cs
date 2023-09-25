namespace TonightPerfume.Data.Repository.BaseRepository
{
    public interface IRepository<T>
    {
        Task Create(T model);
        Task<T> Update(T model);
        Task Delete(T model);
        IEnumerable<T> Get();
        Task<T> GetById(uint id);
    }
}
