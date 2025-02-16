using MediatR;

namespace SuperReich.Application.Features.DynamicFilters.GetByFilter
{
    public class GetByFilterQuery<T>(string? SearchTerm) : IRequest<IReadOnlyList<T>> where T : class;      
}
