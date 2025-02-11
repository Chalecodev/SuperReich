using System.ComponentModel.DataAnnotations;
using SuperReich.Domain.Common;
using SuperReich.Domain.Entities.Customers;
using SuperReich.Domain.Entities.Rooms;
using SuperReich.Domain.Entities.Users;

namespace SuperReich.Domain.Entities.Bookings
{
    public class Booking: Audit
    {
        [Key]
        public int BookingId { get; set; }

        public int UserId { get; set; }
        public User? Users { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customers { get; set; }
        public int RoomId { get; set; }
        public Room? Rooms { get; set; }
    }
}
