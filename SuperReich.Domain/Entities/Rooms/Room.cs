using System.ComponentModel.DataAnnotations;
using SuperReich.Domain.Common;
using SuperReich.Domain.Enums.RoomEnums;

namespace SuperReich.Domain.Entities.Rooms
{
    public class Room : Audit
    {
        [Key]
        public int RoomId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public RoomStatusEnum Status { get; set; }  // Estado de la habitación

        public int RoomPriceId { get; set; }
        public RoomPrice? RoomPrices { get; set; }

        public int RoomCategoryId { get; set; }
        public RoomCategory? RoomCategories { get; set; }
    }
}
