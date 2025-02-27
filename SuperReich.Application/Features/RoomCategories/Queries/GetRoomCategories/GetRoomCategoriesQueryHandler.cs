using System.Globalization;
using AutoMapper;
using MediatR;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Application.DTOs.RoomCategories;
using SuperReich.Domain.Entities.RoomCategories;

namespace SuperReich.Application.Features.RoomCategories.Queries.GetRoomCategories
{
    public class GetRoomCategoriesQueryHandler(IAsyncRepository<RoomCategory> repository, IMapper mapper) : IRequestHandler<GetRoomCategoriesQuery, IReadOnlyList<RoomCategoryDto>>
    {
        private readonly IAsyncRepository<RoomCategory> _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<IReadOnlyList<RoomCategoryDto>> Handle(GetRoomCategoriesQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetAllAsync(p => p.CategoryPrices!);
            var roomCategories = response.Select(roomCategory => new RoomCategoryDto
            {
                RoomCategoryId = roomCategory.RoomCategoryId,
                Description = roomCategory.Description,
                CategoryPriceValue = roomCategory.CategoryPrices != null ? roomCategory.CategoryPrices!.Price.ToString("C0", new CultureInfo("es-CL")) : "0",
                CreatedBy = roomCategory.CreatedBy,
                CreatedDate = roomCategory.CreatedDate,
                LastModifiedBy = roomCategory.LastModifiedBy,
                LastModifiedDate = roomCategory.LastModifiedDate,
                IsActivated = roomCategory.IsActivated
            }).ToList();

            return _mapper.Map<IReadOnlyList<RoomCategoryDto>>(roomCategories);
        }
    }
}
