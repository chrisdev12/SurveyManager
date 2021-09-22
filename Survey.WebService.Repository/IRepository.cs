using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survey.WebService.Repository
{
    public interface IRepository<TEntity> where TEntity: class
    {
        Task<TEntity> Get(string id);

        Task<List<TEntity>> GetAll(string id);

        Task<TEntity> Update(TEntity id);

        Task<TEntity> Insert(TEntity register);
    }
}
