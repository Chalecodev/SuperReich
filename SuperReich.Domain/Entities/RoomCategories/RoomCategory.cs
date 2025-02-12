using System.ComponentModel.DataAnnotations;
using SuperReich.Domain.Common;
using SuperReich.Domain.Entities.RoomPrices;

namespace SuperReich.Domain.Entities.RoomCategories
{
    public class RoomCategory : Audit
    {
        [Key]
        public int RoomCategoryId { get; set; }
        public string Description { get; set; } = string.Empty;

        public int CategoryPriceId { get; set; }
        public CategoryPrice? CategoryPrices { get; set; }
    }
}
