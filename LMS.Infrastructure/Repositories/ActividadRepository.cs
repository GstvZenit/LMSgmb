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
    public class ActividadRepository : IActividadRepository
    {
        private readonly LMS2Context _context;
        public ActividadRepository(LMS2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Actividad>> GetActividades()
        {
            return await _context.Actividad.ToArrayAsync();
        }
        public async Task<Actividad> GetActividad(long Id)
        {
            return await _context.Actividad.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task InsertActividad(Actividad actividad)
        {
            _context.Actividad.Add(actividad);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateActividad(Actividad actividad)
        {
            var currentActividad = await GetActividad(actividad.Id);
            currentActividad.Descripcion = actividad.Descripcion;
            currentActividad.Tipo = actividad.Tipo;
            currentActividad.IdTema = actividad.IdTema;
            currentActividad.Ponderacion = actividad.Ponderacion;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteActividad(long Id)
        {
            var currentActividad = await GetActividad(Id);
            _context.Actividad.Remove(currentActividad);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
