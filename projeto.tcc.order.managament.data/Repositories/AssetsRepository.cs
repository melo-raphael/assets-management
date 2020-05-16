using projeto.tcc.order.managament.data.Context;
using projeto.tcc.order.managament.data.Queries.AssetsQueries;
using projeto.tcc.order.managament.domain;
using projeto.tcc.order.managament.domain.Aggregates.AssetsAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.data.Repositories
{
    public class AssetsRepository : Repository<Assets>, IAssetsRepository
    {

        private readonly IAssetsQuery _assetsQueries;
        public AssetsRepository(ApplicationDbContext appDbContext, IAssetsQuery assetsQuery) : base(appDbContext)
        {
            _assetsQueries = assetsQuery;
        }

        public async Task<IEnumerable<Assets>> GetAssetsPerPage()
        {
            return await _assetsQueries.GetAssetsPerPage();
        }
    }
}
