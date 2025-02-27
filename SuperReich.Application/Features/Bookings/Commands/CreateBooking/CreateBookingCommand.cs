using MediatR;

namespace SuperReich.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<int>
    {
        public string? Notes { get; set; }
        public int PaymentMethodId { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
    }
}
