﻿using MediatR;

namespace SuperReich.Application.Features.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommand: IRequest<int>
    {
        public string Description { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Status { get; set; } = string.Empty;
        public int RoomPriceId { get; set; }
        public int RoomCategoryId { get; set; }
    }
}
