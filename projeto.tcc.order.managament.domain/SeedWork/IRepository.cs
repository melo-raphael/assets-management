using System.Collections.Generic;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.domain.SeedWork
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        void Add(TEntity obj);

    }
}
