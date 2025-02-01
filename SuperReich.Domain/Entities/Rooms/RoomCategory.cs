using System.ComponentModel.DataAnnotations;
using SuperReich.Domain.Common;

namespace SuperReich.Domain.Entities.Rooms
{
    public class RoomCategory: Audit
    {
        [Key]
        public int RoomCategoryId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
