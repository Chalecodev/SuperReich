using AutoMapper;
using MediatR;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Application.DTOs.Rooms;
using SuperReich.Domain.Entities.Rooms;

namespace SuperReich.Application.Features.Rooms.Queries.GetRoomsFiltered
{
    public class GetRoomsFilteredQueryHandler(IAsyncRepository<Room> repository, IMapper mapper) : IRequestHandler<GetRoomsFilteredQuery, IReadOnlyList<RoomDto>>
    {
        private readonly IAsyncRepository<Room> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<IReadOnlyList<RoomDto>> Handle(GetRoomsFilteredQuery request, CancellationToken cancellationToken)
        {
            var roomsFiltered = await _repository.GetFilteredAsync(
                room => room.RoomId.Equals(int.Parse(request.SearchTerm!)) 
                || room.Status.Contains(request.SearchTerm!)
            );

            return _mapper.Map<IReadOnlyList<RoomDto>>(roomsFiltered);
        }
    }
}
