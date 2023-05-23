using System.Net;

namespace Client.Repositories.Interface
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        Task<List<TEntity>> Get();
        Task<TEntity> Get(TKey key);
        HttpStatusCode Post(TEntity entity);
        HttpStatusCode Put(TEntity entity);
        HttpStatusCode Delete(TKey key);
    }
}
