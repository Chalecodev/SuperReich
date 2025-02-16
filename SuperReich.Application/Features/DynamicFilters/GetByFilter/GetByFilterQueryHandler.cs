using AutoMapper;
using MediatR;
using SuperReich.Application.Contracts.Persistence;

namespace SuperReich.Application.Features.DynamicFilters.GetByFilter
{
    public class GetByFilterQueryHandler<T> : IRequestHandler<GetByFilterQuery<T>, IReadOnlyList<T>> where T : class
    {
        private readonly IAsyncRepository<T> _repository;
        private readonly IMapper _mapper;

        public GetByFilterQueryHandler(IAsyncRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<T>> Handle(GetByFilterQuery<T> request, CancellationToken cancellationToken)
        {
            var filters = await _repository.GetFilteredAsync();
            return _mapper.Map<IReadOnlyList<T>>(filters);
        }
    }
}
