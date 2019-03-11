using System.Collections.Generic;
using System.Linq;

namespace Financas.Domain.Interface
{
    public interface IBaseRepository<TEntity>
    {
        void Add(TEntity entity);

        void Delete(int id);

        void Update(TEntity entity);

        TEntity Find(int id);

        IList<TEntity> FindAll();
    }
}
