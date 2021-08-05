using AutoMapper;
using GOPR_HELP_API.Data;
using GOPR_HELP_API.Models;
using GOPR_HELP_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOPR_HELP_API.Controllers
{
    [Route("api/gopr")]
    public class GOPR_HELP_Controller : ControllerBase
    {

        private readonly IGOPR_HELP_Service _service;

        public GOPR_HELP_Controller(IGOPR_HELP_Service Service)
        {
            _service = Service;
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateDto dto,[FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           var isUpdated= _service.Update(id, dto);
            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();
            
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            var isDeleted = _service.Delete(id);
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateTrip([FromBody] CreateRegistrationDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (dto.Start>dto.END)
            {
                return BadRequest("Invalid Time");
            }

            var help=  _service.Create(dto);
           

            return Created($"api/gopr/regi/{help}",null);
        }
        [HttpGet("trails")]
        public ActionResult<IEnumerable<Trails>> GetAll_Trails()
        {
            var get = _service.GetAll_Trails();
            return Ok(get);
        }

        [HttpGet("regi")]//help
        public ActionResult<IEnumerable<Registration>> GetAll_Registration()
        {
            var get = _service.GetAll_regi();
            return Ok(get);
        }
        //dodano
        [HttpGet("regi/{id}")]
        public ActionResult<IEnumerable<Registration>> Get_Registration_Id([FromRoute]int id)
        {
            var get_id = _service.GetById_regi(id);
            if (get_id is null)
            {
                return NotFound();
            }
            return Ok(get_id);
        }

        //dodano
        [HttpGet("mountains")]
        public ActionResult<IEnumerable<Mountains>> GetAll_Mountains()
        {
            var get = _service.GetAll();
            return Ok(get);
        }

        //dodano
        [HttpGet("mountains/{id}")]
        public ActionResult<IEnumerable<Mountains>> Get_Mountains_Id([FromRoute]int id)
        {
            var get_id = _service.GetById(id);
                
            if (get_id is null)
            {
                return NotFound();
            }
            return Ok(get_id);
        }




    }
}
