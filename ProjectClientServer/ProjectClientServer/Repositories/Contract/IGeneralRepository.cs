namespace ProjectClientServer.Repositories.Contract
{
    public interface IGeneralRepository<TEntity, TKey>
        where TEntity : class
        
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(TKey key);
        Task<int> Insert(TEntity entity);
        Task<int> Update(TEntity entity);
        Task<int> Delete(TKey key);

    }
}
