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
    public class CalificacionController : ControllerBase
    {
        //private readonly ICalificacionService _calificacionService;
        private readonly ICalificacionService _calificacionService;
        private readonly IMapper _mapper;
        public CalificacionController(ICalificacionService calificacionService, IMapper mapper)
        {
            _calificacionService = calificacionService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCalificaciones()
        {
            var result = _calificacionService.GetCalificaciones();

            var resultDTO = _mapper.Map<IEnumerable<CalificacionDTO>>(result);
            var response = new APIResponse<IEnumerable<CalificacionDTO>>(resultDTO);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCalificacion(long Id)
        {
            var calificacion = await _calificacionService.GetCalificacion(Id);

            var calificacionDTO = _mapper.Map<CalificacionDTO>(calificacion);
            var response = new APIResponse<CalificacionDTO>(calificacionDTO);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertCalificacion(CalificacionDTO calificacionDTO)
        {

            var calificacion = _mapper.Map<Calificacion>(calificacionDTO);
            await _calificacionService.InsertCalificacion(calificacion);
            calificacionDTO = _mapper.Map<CalificacionDTO>(calificacion);
            var response = new APIResponse<CalificacionDTO>(calificacionDTO);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, CalificacionDTO calificacionDTO)
        {
            var calificacion = _mapper.Map<Calificacion>(calificacionDTO);
            calificacion.Id = Id;
            var result = await _calificacionService.UpdateCalificacion(calificacion);
            calificacionDTO = _mapper.Map<CalificacionDTO>(calificacion);
            var response = new APIResponse<CalificacionDTO>(calificacionDTO);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _calificacionService.DeleteCalificacion(Id);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }

    }
}