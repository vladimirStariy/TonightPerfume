namespace TonightPerfume.Data.Repository.BaseRepository
{
    public interface IRepository<T>
    {
        Task Create(T model);
        Task<T> Update(T model);
        Task Delete(T model);
        IQueryable<T> Get();
        Task<T> GetById(uint id);
    }
}
