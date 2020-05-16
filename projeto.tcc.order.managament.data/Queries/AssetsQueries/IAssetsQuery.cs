using projeto.tcc.order.managament.domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.data.Queries.AssetsQueries
{
    public interface IAssetsQuery : IQueries<Assets>
    {
        Task<IEnumerable<Assets>> GetAssetsPerPage();
    }
}
