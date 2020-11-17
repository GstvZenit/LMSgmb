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
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly LMS2Context _context;
        public EstudianteRepository(LMS2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Estudiante>> GetEstudiantes()
        {
            return await _context.Estudiante.ToArrayAsync();
        }
        public async Task<Estudiante> GetEstudiante(long Id)
        {
            return await _context.Estudiante.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task InsertEstudiante(Estudiante estudiante)
        {
            _context.Estudiante.Add(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateEstudiante(Estudiante estudiante)
        {
            var currentEstudiante = await GetEstudiante(estudiante.Id);
            currentEstudiante.Nombres = estudiante.Nombres;
            currentEstudiante.ApellidoPaterno = estudiante.ApellidoPaterno;
            currentEstudiante.ApellidoMaterno = estudiante.ApellidoMaterno;
            currentEstudiante.Celular = estudiante.Celular;
            currentEstudiante.Telefono = estudiante.Telefono;
            currentEstudiante.Correo = estudiante.Correo;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteEstudiante(long Id)
        {
            var currentEstudiante = await GetEstudiante(Id);
            _context.Estudiante.Remove(currentEstudiante);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
