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
    public class InstructorController : ControllerBase
    {
        //private readonly IInstructorService _instructorService;
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;
        public InstructorController(IInstructorService instructorService, IMapper mapper)
        {
            _instructorService = instructorService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetInstructores()
        {
            var result = _instructorService.GetInstructores();

            var resultDTO = _mapper.Map<IEnumerable<InstructorDTO>>(result);
            var response = new APIResponse<IEnumerable<InstructorDTO>>(resultDTO);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetInstructor(long Id)
        {
            var instructor = await _instructorService.GetInstructor(Id);

            var instructorDTO = _mapper.Map<InstructorDTO>(instructor);
            var response = new APIResponse<InstructorDTO>(instructorDTO);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertInstructor(InstructorDTO instructorDTO)
        {

            var instructor = _mapper.Map<Instructor>(instructorDTO);
            await _instructorService.InsertInstructor(instructor);
            instructorDTO = _mapper.Map<InstructorDTO>(instructor);
            var response = new APIResponse<InstructorDTO>(instructorDTO);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, InstructorDTO instructorDTO)
        {
            var instructor = _mapper.Map<Instructor>(instructorDTO);
            instructor.Id = Id;
            var result = await _instructorService.UpdateInstructor(instructor);
            instructorDTO = _mapper.Map<InstructorDTO>(instructor);
            var response = new APIResponse<InstructorDTO>(instructorDTO);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var result = await _instructorService.DeleteInstructor(Id);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }

    }

}