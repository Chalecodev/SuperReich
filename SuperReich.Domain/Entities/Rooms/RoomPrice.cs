using System.ComponentModel.DataAnnotations;
using SuperReich.Domain.Common;

namespace SuperReich.Domain.Entities.Rooms
{
    public class RoomPrice: Audit
    {
        [Key]
        public int RoomId { get; set; }
        public decimal Price { get; set; }
    }
}
