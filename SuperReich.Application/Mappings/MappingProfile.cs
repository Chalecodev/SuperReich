﻿using AutoMapper;
using SuperReich.Application.DTOs.Rooms;
using SuperReich.Application.DTOs.Users;
using SuperReich.Domain.Entities.Rooms;
using SuperReich.Domain.Entities.Users;

namespace SuperReich.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Room, RoomDto>();
        }
    }
}
