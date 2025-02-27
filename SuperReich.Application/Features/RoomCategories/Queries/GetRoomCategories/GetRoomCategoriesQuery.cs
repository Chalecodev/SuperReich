using MediatR;
using SuperReich.Application.DTOs.RoomCategories;

namespace SuperReich.Application.Features.RoomCategories.Queries.GetRoomCategories
{
    public class GetRoomCategoriesQuery : IRequest<IReadOnlyList<RoomCategoryDto>>;
}
