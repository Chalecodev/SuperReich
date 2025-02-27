using MediatR;
using SuperReich.Application.Contracts.Persistence;
using SuperReich.Domain.Entities.Rooms;

namespace SuperReich.Application.Features.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandHandler(IAsyncRepository<Room> repository) : IRequestHandler<CreateRoomCommand, int>
    {
        private readonly IAsyncRepository<Room> _repository = repository;

        public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Room
            {
                Description = request.Description,
                Capacity = request.Capacity,
                Status = request.Status,
                NumberRoom = request.NumberRoom,
                RoomCategoryId = request.RoomCategoryId,
            };

            var result = await _repository.AddAsync(room);
            return result.RoomId;
        }
    }
}
