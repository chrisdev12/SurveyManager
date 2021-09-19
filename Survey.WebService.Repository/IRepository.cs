using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survey.WebService.Repository
{
    public interface IRepository<TEntity> where TEntity: class
    {
        Task<TEntity> GetById(TEntity id);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> Update(TEntity id);

        Task<TEntity> Insert(TEntity register);
    }
}
