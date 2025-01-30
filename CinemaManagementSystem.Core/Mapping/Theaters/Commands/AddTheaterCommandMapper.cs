﻿using CinemaManagementSystem.Core.Features.Theaters.Commands.Models;
using CinemaManagementSystem.Data.Entities;

namespace CinemaManagementSystem.Core.Mapping.Theaters
{
    public partial class TheatersProfiles
    {
        public void AddTheaterCommandMapper()
        {
            CreateMap<AddTheaterCommand, Theater>();
        }

    }
}
