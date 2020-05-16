using MediatR;
using Microsoft.Extensions.Caching.Memory;
using projeto.tcc.order.managament.application.Behaviours;
using System.Threading;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.application
{
    public class PipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IMemoryCache _cache;
        public PipelineBehavior(IMemoryCache cache)
        {
            _cache = cache;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is IProvideCacheKey cacheableRequest)
            {
                var cacheKey = cacheableRequest.CacheKey;
                // Check in cache if we already have what we're looking for
                if (_cache.TryGetValue<TResponse>(cacheKey, out var cachedResponse))
                {
                    return cachedResponse;
                }
                // If we don't, execute the rest of the pipeline, and add the result to the cache
                var response = await next();
                _cache.Set(cacheKey, response);
                return response;
            }
            else
            {
                return await next();
            }
        }
    }
}
