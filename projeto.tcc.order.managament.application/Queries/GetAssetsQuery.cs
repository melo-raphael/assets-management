using MediatR;
using projeto.tcc.order.managament.application.Behaviours;
using projeto.tcc.order.managament.application.Dtos;
using System.Collections.Generic;

namespace projeto.tcc.order.managament.application.Queries
{
    public class GetAssetsQuery : Query, IRequest<IEnumerable<GetAllAssetsResponseDto>>, IProvideCacheKey
    {

        public string PageNumber { get; set; }

        public string CacheKey => $"{GetType().Name}:{PageNumber}";

        public GetAssetsQuery(string pageNumber)
        {
            PageNumber = pageNumber;
        }

    }
}
