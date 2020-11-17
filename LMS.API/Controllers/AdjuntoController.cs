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
    public class AdjuntoController : ControllerBase
    {
        //private readonly IAdjuntoService _adjuntoService;
        private readonly IAdjuntoService _adjuntoService;
        private readonly IMapper _mapper;
        public AdjuntoController(IAdjuntoService adjuntoService, IMapper mapper)
        {
            _adjuntoService = adjuntoService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAdjuntos()
        {
            var result = _adjuntoService.GetAdjuntos();

            var resultDTO = _mapper.Map<IEnumerable<AdjuntoDTO>>(result);
            var response = new APIResponse<IEnumerable<AdjuntoDTO>>(resultDTO);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAdjunto(long Id)
        {
            var adjunto = await _adjuntoService.GetAdjunto(Id);

            var adjuntoDTO = _mapper.Map<AdjuntoDTO>(adjunto);
            var response = new APIResponse<AdjuntoDTO>(adjuntoDTO);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertAdjunto(AdjuntoDTO adjuntoDTO)
        {

            var adjunto = _mapper.Map<Adjunto>(adjuntoDTO);
            await _adjuntoService.InsertAdjunto(adjunto);
            adjuntoDTO = _mapper.Map<AdjuntoDTO>(adjunto);
            var response = new APIResponse<AdjuntoDTO>(adjuntoDTO);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, AdjuntoDTO adjuntoDTO)
        {
            var adjunto = _mapper.Map<Adjunto>(adjuntoDTO);
            adjunto.Id = Id;
            var result = await _adjuntoService.UpdateAdjunto(adjunto);
            adjuntoDTO = _mapper.Map<AdjuntoDTO>(adjunto);
            var response = new APIResponse<AdjuntoDTO>(adjuntoDTO);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _adjuntoService.DeleteAdjunto(Id);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }

    }
}