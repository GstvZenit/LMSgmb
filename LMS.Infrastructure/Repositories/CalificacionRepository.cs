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
    public class CalificacionRepository : ICalificacionRepository
    {
        private readonly LMS2Context _context;
        public CalificacionRepository(LMS2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Calificacion>> GetCalificaciones()
        {
            return await _context.Calificacion.ToArrayAsync();
        }
        public async Task<Calificacion> GetCalificacion(long Id)
        {
            return await _context.Calificacion.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task InsertCalificacion(Calificacion calificacion)
        {
            _context.Calificacion.Add(calificacion);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCalificacion(Calificacion calificacion)
        {
            var currentCalificacion = await GetCalificacion(calificacion.Id);
            currentCalificacion.FechaCalificacion = calificacion.FechaCalificacion;
            currentCalificacion.Nota = calificacion.Nota;
            currentCalificacion.IdInscripcion = calificacion.IdInscripcion;
            currentCalificacion.IdActividad = calificacion.IdActividad;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteCalificacion(long Id)
        {
            var currentCalificacion = await GetCalificacion(Id);
            _context.Calificacion.Remove(currentCalificacion);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
