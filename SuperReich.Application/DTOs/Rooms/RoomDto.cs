using SuperReich.Domain.Common;
using SuperReich.Domain.Entities.Rooms;

namespace SuperReich.Application.DTOs.Rooms
{
    public class RoomDto: Audit
    {
        public int RoomId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int NumberRoom { get; set; }
        public string Status { get; set; } = string.Empty;
        public string RoomCategoryName { get; set; } = string.Empty;
    }
}
