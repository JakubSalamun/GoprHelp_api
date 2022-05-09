using GOPR_HELP_API.Models;
using System.Collections.Generic;

namespace GOPR_HELP_API.Services
{
    public interface IGOPR_HELP_Service
    {
        int Create(CreateRegistrationDto dto);
        bool Delete(int id);
        bool Update(int id, UpdateDto dto);
        IEnumerable<TrailsDto> GetAll_Trails();
        IEnumerable<MountainsDto> GetAll();
        IEnumerable<RegistrationDto> GetAll_regi();
        MountainsDto GetById(int id);
        RegistrationDto GetById_regi(int id);
    }
}