using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LMS.Core.Entities;
using LMS.Core.Interfaces;
using LMS.Core.DTO;
using AutoMapper;
using LMS.API.Responses;
using LMS.Core.Services;
namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        //private readonly IActividadService _actividadService;
        private readonly IActividadService _actividadService;
        private readonly IMapper _mapper;
        public ActividadController(IActividadService actividadService, IMapper mapper)
        {
            _actividadService = actividadService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetActividades()
        {
            var result = _actividadService.GetActividades();

            var resultDTO = _mapper.Map<IEnumerable<ActividadDTO>>(result);
            var response = new APIResponse<IEnumerable<ActividadDTO>>(resultDTO);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetActividad(long Id)
        {
            var actividad = await _actividadService.GetActividad(Id);

            var actividadDTO = _mapper.Map<ActividadDTO>(actividad);
            var response = new APIResponse<ActividadDTO>(actividadDTO);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertActividad(ActividadDTO actividadDTO)
        {

            var actividad = _mapper.Map<Actividad>(actividadDTO);
            await _actividadService.InsertActividad(actividad);
            actividadDTO = _mapper.Map<ActividadDTO>(actividad);
            var response = new APIResponse<ActividadDTO>(actividadDTO);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, ActividadDTO actividadDTO)
        {
            var actividad = _mapper.Map<Actividad>(actividadDTO);
            actividad.Id = Id;
            var result = await _actividadService.UpdateActividad(actividad);
            actividadDTO = _mapper.Map<ActividadDTO>(actividad);
            var response = new APIResponse<ActividadDTO>(actividadDTO);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _actividadService.DeleteActividad(Id);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }

    }
}