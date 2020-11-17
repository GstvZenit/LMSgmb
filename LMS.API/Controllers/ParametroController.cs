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
    public class ParametroController : ControllerBase
    {
        //private readonly IParametroService _parametroService;
        private readonly IParametroService _parametroService;
        private readonly IMapper _mapper;
        public ParametroController(IParametroService parametroService, IMapper mapper)
        {
            _parametroService = parametroService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetParametros()
        {
            var result = _parametroService.GetParametros();

            var resultDTO = _mapper.Map<IEnumerable<ParametroDTO>>(result);
            var response = new APIResponse<IEnumerable<ParametroDTO>>(resultDTO);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetParametro(long Id)
        {
            var parametro = await _parametroService.GetParametro(Id);

            var parametroDTO = _mapper.Map<ParametroDTO>(parametro);
            var response = new APIResponse<ParametroDTO>(parametroDTO);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertParametro(ParametroDTO parametroDTO)
        {

            var parametro = _mapper.Map<Parametro>(parametroDTO);
            await _parametroService.InsertParametro(parametro);
            parametroDTO = _mapper.Map<ParametroDTO>(parametro);
            var response = new APIResponse<ParametroDTO>(parametroDTO);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, ParametroDTO parametroDTO)
        {
            var parametro = _mapper.Map<Parametro>(parametroDTO);
            parametro.Id = Id;
            var result = await _parametroService.UpdateParametro(parametro);
            parametroDTO = _mapper.Map<ParametroDTO>(parametro);
            var response = new APIResponse<ParametroDTO>(parametroDTO);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _parametroService.DeleteParametro(Id);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }

    }
}