using MediatR;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Domain.Entities.Bookings;

namespace SuperReich.Application.Features.Bookings.Queries.GetBookings
{
    public class GetBookingsQueryHandler(IAsyncRepository<Booking> repository) : IRequestHandler<GetBookingsQuery, IReadOnlyList<Booking>>
    {
        private readonly IAsyncRepository<Booking> _repository = repository;

        public async Task<IReadOnlyList<Booking>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetAllAsync();
            var bookings = response.Select(booking => new Booking
            {
                BookingId = booking.BookingId,
                RoomId = booking.RoomId,
                PaymentMethodId = booking.PaymentMethodId,
                CustomerId = booking.CustomerId,
                Notes = booking.Notes,
                CreatedBy = booking.CreatedBy,
                CreatedDate = booking.CreatedDate,
                LastModifiedBy = booking.LastModifiedBy,
                LastModifiedDate = booking.LastModifiedDate,
                IsActivated = booking.IsActivated
            }).ToList();

            return bookings;
        }
    }
}
