using System;
using System.Collections.Generic;
using System.Text;
using LMS.Core.Entities;
using LMS.Core.Interfaces;
using LMS.Infrastructure.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace LMS.Infrastructure.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly LMS2Context _context;
        public InstructorRepository(LMS2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Instructor>> GetInstructores()
        {
            return await _context.Instructor.ToArrayAsync();
        }
        public async Task<Instructor> GetInstructor(long Id)
        {
            return await _context.Instructor.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task InsertInstructor(Instructor instructor)
        {
            _context.Instructor.Add(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateInstructor(Instructor instructor)
        {
            var currentInstructor = await GetInstructor(instructor.Id);
            currentInstructor.NombresApellidos = instructor.NombresApellidos;
            currentInstructor.Celular = instructor.Celular;
            currentInstructor.Telefono = instructor.Telefono;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteInstructor(long Id)
        {
            var currentInstructor = await GetInstructor(Id);
            _context.Instructor.Remove(currentInstructor);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
