using SuperReich.Domain.Common;

namespace SuperReich.Application.DTOs.RoomCategories
{
    public class RoomCategoryDto: Audit
    {
        public int RoomCategoryId { get; set; }
        public string Description { get; set; } = string.Empty;

        public string CategoryPriceValue { get; set; } = string.Empty;
    }
}
