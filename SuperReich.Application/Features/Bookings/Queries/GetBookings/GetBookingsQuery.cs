using MediatR;
using SuperReich.Domain.Entities.Bookings;

namespace SuperReich.Application.Features.Bookings.Queries.GetBookings
{
    public class GetBookingsQuery: IRequest<IReadOnlyList<Booking>>;
}
