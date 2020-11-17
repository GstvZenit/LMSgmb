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
    public class ControlasistenciaController : ControllerBase
    {
        //private readonly IControlasistenciaService _controlasistenciaService;
        private readonly IControlasistenciaService _controlasistenciaService;
        private readonly IMapper _mapper;
        public ControlasistenciaController(IControlasistenciaService controlasistenciaService, IMapper mapper)
        {
            _controlasistenciaService = controlasistenciaService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetControlasistencias()
        {
            var result = _controlasistenciaService.GetControlasistencias();

            var resultDTO = _mapper.Map<IEnumerable<ControlasistenciaDTO>>(result);
            var response = new APIResponse<IEnumerable<ControlasistenciaDTO>>(resultDTO);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetControlasistencia(long Id)
        {
            var controlasistencia = await _controlasistenciaService.GetControlasistencia(Id);

            var controlasistenciaDTO = _mapper.Map<ControlasistenciaDTO>(controlasistencia);
            var response = new APIResponse<ControlasistenciaDTO>(controlasistenciaDTO);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertControlasistencia(ControlasistenciaDTO controlasistenciaDTO)
        {

            var controlasistencia = _mapper.Map<Controlasistencia>(controlasistenciaDTO);
            await _controlasistenciaService.InsertControlasistencia(controlasistencia);
            controlasistenciaDTO = _mapper.Map<ControlasistenciaDTO>(controlasistencia);
            var response = new APIResponse<ControlasistenciaDTO>(controlasistenciaDTO);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, ControlasistenciaDTO controlasistenciaDTO)
        {
            var controlasistencia = _mapper.Map<Controlasistencia>(controlasistenciaDTO);
            controlasistencia.Id = Id;
            var result = await _controlasistenciaService.UpdateControlasistencia(controlasistencia);
            controlasistenciaDTO = _mapper.Map<ControlasistenciaDTO>(controlasistencia);
            var response = new APIResponse<ControlasistenciaDTO>(controlasistenciaDTO);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _controlasistenciaService.DeleteControlasistencia(Id);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }

    }
}