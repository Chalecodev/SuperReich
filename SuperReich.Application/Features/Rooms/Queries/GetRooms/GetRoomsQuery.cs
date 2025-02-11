using MediatR;
using SuperReich.Application.DTOs.Rooms;

namespace SuperReich.Application.Features.Rooms.Queries.GetRooms
{
    public class GetRoomsQuery: IRequest<IReadOnlyList<RoomDto>>;
}
