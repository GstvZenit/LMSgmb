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
    public class TemaController : ControllerBase
    {
        //private readonly ITemaService _temaService;
        private readonly ITemaService _temaService;
        private readonly IMapper _mapper;
        public TemaController(ITemaService temaService, IMapper mapper)
        {
            _temaService = temaService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetTemas()
        {
            var result = _temaService.GetTemas();
           
            var resultDTO = _mapper.Map<IEnumerable<TemaDTO>>(result);
            var response = new APIResponse<IEnumerable<TemaDTO>>(resultDTO);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTema(long Id)
        {
            var tema = await _temaService.GetTema(Id);
            
            var temaDTO = _mapper.Map<TemaDTO>(tema);
            var response = new APIResponse<TemaDTO>(temaDTO);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertTema(TemaDTO temaDTO)
        {
           
            var tema = _mapper.Map<Tema>(temaDTO);
            await _temaService.InsertTema(tema);
            temaDTO = _mapper.Map<TemaDTO>(tema);
            var response = new APIResponse<TemaDTO>(temaDTO);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, TemaDTO temaDTO)
        {
            var tema = _mapper.Map<Tema>(temaDTO);
            tema.Id = Id;
            var result = await _temaService.UpdateTema(tema);
            temaDTO = _mapper.Map<TemaDTO>(tema);
            var response = new APIResponse<TemaDTO>(temaDTO);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _temaService.DeleteTema(Id);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }

    }
}