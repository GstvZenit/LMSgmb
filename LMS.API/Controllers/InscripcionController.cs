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
    public class InscripcionController : ControllerBase
    {
        //private readonly IInscripcionService _inscripcionService;
        private readonly IInscripcionService _inscripcionService;
        private readonly IMapper _mapper;
        public InscripcionController(IInscripcionService inscripcionService, IMapper mapper)
        {
            _inscripcionService = inscripcionService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetInscripciones()
        {
            var result = _inscripcionService.GetInscripciones();

            var resultDTO = _mapper.Map<IEnumerable<InscripcionDTO>>(result);
            var response = new APIResponse<IEnumerable<InscripcionDTO>>(resultDTO);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetInscripcion(long Id)
        {
            var inscripcion = await _inscripcionService.GetInscripcion(Id);

            var inscripcionDTO = _mapper.Map<InscripcionDTO>(inscripcion);
            var response = new APIResponse<InscripcionDTO>(inscripcionDTO);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertInscripcion(InscripcionDTO inscripcionDTO)
        {

            var inscripcion = _mapper.Map<Inscripcion>(inscripcionDTO);
            await _inscripcionService.InsertInscripcion(inscripcion);
            inscripcionDTO = _mapper.Map<InscripcionDTO>(inscripcion);
            var response = new APIResponse<InscripcionDTO>(inscripcionDTO);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, InscripcionDTO inscripcionDTO)
        {
            var inscripcion = _mapper.Map<Inscripcion>(inscripcionDTO);
            inscripcion.Id = Id;
            var result = await _inscripcionService.UpdateInscripcion(inscripcion);
            inscripcionDTO = _mapper.Map<InscripcionDTO>(inscripcion);
            var response = new APIResponse<InscripcionDTO>(inscripcionDTO);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _inscripcionService.DeleteInscripcion(Id);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }

    }
}