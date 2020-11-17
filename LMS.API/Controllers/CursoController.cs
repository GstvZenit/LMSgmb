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
    public class CursoController : ControllerBase
    {
        //private readonly ICursoService _cursoService;
        private readonly ICursoService _cursoService;
        private readonly IMapper _mapper;
        public CursoController(ICursoService cursoService, IMapper mapper)
        {
            _cursoService = cursoService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCursos()
        {
            var result = _cursoService.GetCursos();

            var resultDTO = _mapper.Map<IEnumerable<CursoDTO>>(result);
            var response = new APIResponse<IEnumerable<CursoDTO>>(resultDTO);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCurso(long Id)
        {
            var curso = await _cursoService.GetCurso(Id);

            var cursoDTO = _mapper.Map<CursoDTO>(curso);
            var response = new APIResponse<CursoDTO>(cursoDTO);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertCurso(CursoDTO cursoDTO)
        {

            var curso = _mapper.Map<Curso>(cursoDTO);
            await _cursoService.InsertCurso(curso);
            cursoDTO = _mapper.Map<CursoDTO>(curso);
            var response = new APIResponse<CursoDTO>(cursoDTO);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, CursoDTO cursoDTO)
        {
            var curso = _mapper.Map<Curso>(cursoDTO);
            curso.Id = Id;
            var result = await _cursoService.UpdateCurso(curso);
            cursoDTO = _mapper.Map<CursoDTO>(curso);
            var response = new APIResponse<CursoDTO>(cursoDTO);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _cursoService.DeleteCurso(Id);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }

    }
}