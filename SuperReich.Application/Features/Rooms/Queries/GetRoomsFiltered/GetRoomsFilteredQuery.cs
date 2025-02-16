using MediatR;
using SuperReich.Application.DTOs.Rooms;

namespace SuperReich.Application.Features.Rooms.Queries.GetRoomsFiltered
{
    public record GetRoomsFilteredQuery(string? SearchTerm) : IRequest<IReadOnlyList<RoomDto>>;
}
