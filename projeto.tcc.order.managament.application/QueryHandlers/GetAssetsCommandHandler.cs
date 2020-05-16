using AutoMapper;
using MediatR;
using projeto.tcc.order.managament.application.Dtos;
using projeto.tcc.order.managament.application.Queries;
using projeto.tcc.order.managament.application.QueryHandlers;
using projeto.tcc.order.managament.domain;
using projeto.tcc.order.managament.domain.Aggregates.AssetsAggregate;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.application.CommandsHandlers
{
    public class GetAssetsCommandHandler : QueryHandler, IRequestHandler<GetAssetsQuery, IEnumerable<GetAllAssetsResponseDto>>
    {

        private readonly IAssetsRepository _assetsRepository;
        private readonly IMapper _mapper;

        public GetAssetsCommandHandler(
            IMapper mapper,
            IAssetsRepository assetsRepository)
        {
            _assetsRepository = assetsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllAssetsResponseDto>> Handle(GetAssetsQuery command, CancellationToken cancellationToken)
        {
            var queryResult = await _assetsRepository.GetAssetsPerPage();

            var response =  _mapper.Map<IEnumerable<Assets>, IEnumerable<GetAllAssetsResponseDto>>(queryResult);

            return response;

        }
    }
}
