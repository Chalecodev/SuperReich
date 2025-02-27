using System.ComponentModel.DataAnnotations;
using SuperReich.Domain.Common;
using SuperReich.Domain.Entities.Customers;
using SuperReich.Domain.Entities.PaymentMethods;
using SuperReich.Domain.Entities.Rooms;

namespace SuperReich.Domain.Entities.Bookings
{
    public class Booking: Audit
    {
        [Key]
        public int BookingId { get; set; }
        public string? Notes { get; set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod? PaymentMethods { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customers { get; set; }

        public int RoomId { get; set; }
        public Room? Rooms { get; set; }
    }
}
