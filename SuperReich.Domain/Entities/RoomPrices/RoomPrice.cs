using System.ComponentModel.DataAnnotations;
using SuperReich.Domain.Common;

namespace SuperReich.Domain.Entities.RoomPrices
{
    public class RoomPrice : Audit
    {
        [Key]
        public int RoomPriceId { get; set; }
        public decimal Price { get; set; }
        public string? Season { get; set; }
        public string? PriceType { get; set; }
    }
}
