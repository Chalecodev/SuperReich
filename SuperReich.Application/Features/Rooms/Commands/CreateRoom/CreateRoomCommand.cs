using MediatR;

namespace SuperReich.Application.Features.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommand: IRequest<int>
    {
        public string Description { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int NumberRoom { get; set; }
        public string Status { get; set; } = string.Empty;
        public int RoomCategoryId { get; set; }
    }
}
