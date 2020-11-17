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
    public class ControlasistenciaRepository : IControlasistenciaRepository
    {
        private readonly LMS2Context _context;
        public ControlasistenciaRepository(LMS2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Controlasistencia>> GetControlasistencias()
        {
            return await _context.Controlasistencia.ToArrayAsync();
        }
        public async Task<Controlasistencia> GetControlasistencia(long Id)
        {
            return await _context.Controlasistencia.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task InsertControlasistencia(Controlasistencia controlasistencia)
        {
            _context.Controlasistencia.Add(controlasistencia);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateControlasistencia(Controlasistencia controlasistencia)
        {
            var currentControlasistencia = await GetControlasistencia(controlasistencia.Id);
            currentControlasistencia.FechaAsistencia = controlasistencia.FechaAsistencia;
            currentControlasistencia.Asistio = controlasistencia.Asistio;
            currentControlasistencia.IdInscripcion = controlasistencia.IdInscripcion;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteControlasistencia(long Id)
        {
            var currentControlasistencia = await GetControlasistencia(Id);
            _context.Controlasistencia.Remove(currentControlasistencia);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
