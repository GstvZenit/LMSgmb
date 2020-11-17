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
    public class UsuarioController : ControllerBase
    {
        //private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioService usuarioService,IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetUsuarios()
        {
            var result =  _usuarioService.GetUsuarios();
            var resultDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(result);
            var response = new APIResponse<IEnumerable<UsuarioDTO>>(resultDTO);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUsuario(long Id)
        {
            var usuario =await _usuarioService.GetUsuario(Id);
            
            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            var response = new APIResponse<UsuarioDTO>(usuarioDTO);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertUsuario(UsuarioDTO usuarioDTO)
        {
            
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            await _usuarioService.InsertUsuario(usuario);
            usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            var response = new APIResponse<UsuarioDTO>(usuarioDTO);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            usuario.Id = Id;
            var result= await _usuarioService.UpdateUsuario(usuario);
            usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            var response = new APIResponse<UsuarioDTO>(usuarioDTO);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _usuarioService.DeleteUsuario(Id);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }

    }
}