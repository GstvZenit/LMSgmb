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
    public class EstudianteController : ControllerBase
    {
        //private readonly IEstudianteService _estudianteService;
        private readonly IEstudianteService _estudianteService;
        private readonly IMapper _mapper;
        public EstudianteController(IEstudianteService estudianteService, IMapper mapper)
        {
            _estudianteService = estudianteService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetEstudiantes()
        {
            var result = _estudianteService.GetEstudiantes();

            var resultDTO = _mapper.Map<IEnumerable<EstudianteDTO>>(result);
            var response = new APIResponse<IEnumerable<EstudianteDTO>>(resultDTO);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEstudiante(long Id)
        {
            var estudiante = await _estudianteService.GetEstudiante(Id);

            var estudianteDTO = _mapper.Map<EstudianteDTO>(estudiante);
            var response = new APIResponse<EstudianteDTO>(estudianteDTO);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertEstudiante(EstudianteDTO estudianteDTO)
        {

            var estudiante = _mapper.Map<Estudiante>(estudianteDTO);
            await _estudianteService.InsertEstudiante(estudiante);
            estudianteDTO = _mapper.Map<EstudianteDTO>(estudiante);
            var response = new APIResponse<EstudianteDTO>(estudianteDTO);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, EstudianteDTO estudianteDTO)
        {
            var estudiante = _mapper.Map<Estudiante>(estudianteDTO);
            estudiante.Id = Id;
            var result = await _estudianteService.UpdateEstudiante(estudiante);
            estudianteDTO = _mapper.Map<EstudianteDTO>(estudiante);
            var response = new APIResponse<EstudianteDTO>(estudianteDTO);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _estudianteService.DeleteEstudiante(Id);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }

    }
}