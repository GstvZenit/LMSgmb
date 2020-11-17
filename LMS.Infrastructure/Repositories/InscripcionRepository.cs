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
    public class InscripcionRepository : IInscripcionRepository
    {
        private readonly LMS2Context _context;
        public InscripcionRepository(LMS2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Inscripcion>> GetInscripciones()
        {
            return await _context.Inscripcion.ToArrayAsync();
        }
        public async Task<Inscripcion> GetInscripcion(long Id)
        {
            return await _context.Inscripcion.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task InsertInscripcion(Inscripcion inscripcion)
        {
            _context.Inscripcion.Add(inscripcion);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateInscripcion(Inscripcion inscripcion)
        {
            var currentInscripcion = await GetInscripcion(inscripcion.Id);
            currentInscripcion.Estado = inscripcion.Estado;
            currentInscripcion.IdCurso = inscripcion.IdCurso;
            currentInscripcion.IdEstudiante = inscripcion.IdEstudiante;
            currentInscripcion.FechaCreacion = inscripcion.FechaCreacion;
            currentInscripcion.FechaActualizacion = inscripcion.FechaActualizacion;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteInscripcion(long Id)
        {
            var currentInscripcion = await GetInscripcion(Id);
            _context.Inscripcion.Remove(currentInscripcion);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
