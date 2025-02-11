using System.ComponentModel.DataAnnotations;
using SuperReich.Domain.Common;
using SuperReich.Domain.Entities.RoomCategories;

namespace SuperReich.Domain.Entities.Rooms
{
    public class Room : Audit
    {
        [Key]
        public int RoomId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int NumberRoom { get; set; }
        public string Status { get; set; } = string.Empty;

        public int RoomCategoryId { get; set; }
        public RoomCategory? RoomCategories { get; set; }
    }
}
