using MediatR;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Domain.Entities.Bookings;

namespace SuperReich.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommandHandler(IAsyncRepository<Booking> repository) : IRequestHandler<CreateBookingCommand, int>
    {
        private readonly IAsyncRepository<Booking> _repository = repository;

        public async Task<int> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = new Booking
            {
                Notes = request.Notes,
                PaymentMethodId = request.PaymentMethodId,
                CustomerId = request.CustomerId,
                RoomId = request.RoomId
            };

            var response = await _repository.AddAsync(booking);
            return response.BookingId;
        }
    }
}
