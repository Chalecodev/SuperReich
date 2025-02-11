using System.ComponentModel.DataAnnotations;
using SuperReich.Domain.Common;
using SuperReich.Domain.Entities.Bookings;
using SuperReich.Domain.Entities.Products;

namespace SuperReich.Domain.Entities.Orders
{
    public class Order: Audit
    {
        [Key]
        public int OrderId { get; set; }
        
        public int BookingId { get; set; }
        public Booking? Bookings { get; set; }
        public int ProductId { get; set; }
        public Product? Products { get; set; }
    }
}
