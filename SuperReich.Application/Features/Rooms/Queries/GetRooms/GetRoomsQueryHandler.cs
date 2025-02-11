using AutoMapper;
using MediatR;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Application.DTOs.Rooms;
using SuperReich.Application.DTOs.Users;
using SuperReich.Domain.Entities.Rooms;
using SuperReich.Domain.Entities.Users;

namespace SuperReich.Application.Features.Rooms.Queries.GetRooms
{
    public class GetRoomsQueryHandler(IAsyncRepository<Room> repository, IMapper mapper) : IRequestHandler<GetRoomsQuery, IReadOnlyList<RoomDto>>
    {
        private readonly IAsyncRepository<Room> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<IReadOnlyList<RoomDto>> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetAllAsync(category => category.RoomCategories!);
            var rooms = response.Select(room => new RoomDto
            {
                RoomId = room.RoomId,
                Description = room.Description,
                Capacity = room.Capacity,
                NumberRoom = room.NumberRoom,
                Status = room.Status,
                RoomCategoryName = room.RoomCategories != null ? room.RoomCategories.Description : string.Empty,
                CreatedBy = "Chaleco",
                LastModifiedBy = null,
                IsDeleted = false
            }).ToList();

            return _mapper.Map<IReadOnlyList<RoomDto>>(rooms);
        }
    }
}
