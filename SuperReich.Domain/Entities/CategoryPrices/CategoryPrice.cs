using System.ComponentModel.DataAnnotations;
using SuperReich.Domain.Common;

namespace SuperReich.Domain.Entities.RoomPrices
{
    public class CategoryPrice: Audit
    {
        [Key]
        public int CategoryPriceId { get; set; }
        public decimal Price { get; set; }
        public string Season { get; set; } = string.Empty;
        public string PriceType { get; set; } = string.Empty;
    }
}
