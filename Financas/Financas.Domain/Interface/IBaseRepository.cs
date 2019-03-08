using System.Collections.Generic;

namespace Financas.Domain.Interface
{
    public interface IBaseRepository<TEntity>
    {
        void Add(TEntity entity);

        void Delete(int id);

        void Update(TEntity entity);

        TEntity Find(int id);

        ICollection<TEntity> FindAll();
    }
}
