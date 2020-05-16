using projeto.tcc.order.managament.domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.domain.Aggregates.AssetsAggregate
{
    public interface IAssetsRepository : IRepository<Assets>
    {
        Task<IEnumerable<Assets>> GetAssetsPerPage();
    }
}
