using AutoMapper;
using GOPR_HELP_API.Data;
using GOPR_HELP_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOPR_HELP_API.Services
{
    public class GOPR_HELP_Service : IGOPR_HELP_Service
    {
        private readonly GOPR_HELP_DbContext _db;
        private readonly IMapper _mapper;
        public GOPR_HELP_Service(GOPR_HELP_DbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public bool Update(int id,UpdateDto dto)
        {
            var trails = _db.Trails.FirstOrDefault(r => r.Id == id);
            if (trails is null)
            {
                return false;
            }
            trails.Name = dto.Name;
            trails.Length = dto.Length;
            trails.Status = dto.Status;
            _db.SaveChanges();
            return true;

        }
        public bool Delete(int id)
        {
            var registation = _db.Registrations.FirstOrDefault(r => r.Id == id);
            if (registation is null)
            {
                return false;
            }
            _db.Registrations.Remove(registation);
            _db.SaveChanges();
            return true;
        }

        //Wyświeltanie
        public IEnumerable<TrailsDto> GetAll_Trails()
        {
            var trails=_db.Trails.ToList();
            var result = _mapper.Map<List<TrailsDto>>(trails);
            return result;
        }
        public MountainsDto GetById(int id)
        {
            var mountains = _db
              .Mountains
              .Include(r => r.Trails)
              .FirstOrDefault(x => x.Id == id);

            if (mountains is null)
            {
                return null;
            }
            var result = _mapper.Map<MountainsDto>(mountains);
            return result;
        }
        public RegistrationDto GetById_regi(int id)
        {
            var registration = _db
                .Registrations
                .FirstOrDefault(x => x.Id == id);
            if (registration is null)
            {
                return null;
            }
            var result = _mapper.Map<RegistrationDto>(registration);
            return result;
        }

        public IEnumerable<MountainsDto> GetAll()
        {
            var mountains = _db
               .Mountains
               .Include(r => r.Trails)
               .ToList();
            var result = _mapper.Map<List<MountainsDto>>(mountains);
            return result;

        }
        public IEnumerable<RegistrationDto> GetAll_regi()
        {
            var registration = _db
                .Registrations
                .ToList();
            var result = _mapper.Map<List<RegistrationDto>>(registration);
            return result;

        }
        //Tworzenie
        public int Create(CreateRegistrationDto dto)
        {
            var result = _mapper.Map<Registration>(dto);
            _db.Registrations.Add(result);
            _db.SaveChanges();
            return result.Id;
        }
    }
}
