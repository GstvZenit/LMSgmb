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
    public class RolController : ControllerBase
    {
        //private readonly IRolService _rolService;
        private readonly IRolService _rolService;
        private readonly IMapper _mapper;
        public RolController(IRolService rolService, IMapper mapper)
        {
            _rolService = rolService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetRoles()
        {
            var result = _rolService.GetRoles();

            var resultDTO = _mapper.Map<IEnumerable<RolDTO>>(result);
            var response = new APIResponse<IEnumerable<RolDTO>>(resultDTO);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetRol(long Id)
        {
            var rol = await _rolService.GetRol(Id);

            var rolDTO = _mapper.Map<RolDTO>(rol);
            var response = new APIResponse<RolDTO>(rolDTO);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertRol(RolDTO rolDTO)
        {

            var rol = _mapper.Map<Rol>(rolDTO);
            await _rolService.InsertRol(rol);
            rolDTO = _mapper.Map<RolDTO>(rol);
            var response = new APIResponse<RolDTO>(rolDTO);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, RolDTO rolDTO)
        {
            var rol = _mapper.Map<Rol>(rolDTO);
            rol.Id = Id;
            var result = await _rolService.UpdateRol(rol);
            rolDTO = _mapper.Map<RolDTO>(rol);
            var response = new APIResponse<RolDTO>(rolDTO);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _rolService.DeleteRol(Id);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }

    }
}