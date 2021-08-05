using AutoMapper;
using GOPR_HELP_API.Data;
using GOPR_HELP_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOPR_HELP_API
{
    public class GOPR_HELP_Profile : Profile
    {
        public GOPR_HELP_Profile()
        {
            CreateMap<Mountains, MountainsDto>();
            CreateMap<Trails, TrailsDto>();
            CreateMap<Registration, RegistrationDto>();
            CreateMap<CreateRegistrationDto, Registration>();
            
        }
    }
}
