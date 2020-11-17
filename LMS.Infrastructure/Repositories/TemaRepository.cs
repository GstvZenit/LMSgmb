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
    public class TemaRepository : ITemaRepository
    {
        private readonly LMS2Context _context;
        public TemaRepository(LMS2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Tema>> GetTemas()
        {
            return await _context.Tema.ToArrayAsync();
        }
        public async Task<Tema> GetTema(long Id)
        {
            return await _context.Tema.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task InsertTema(Tema tema)
        {
            _context.Tema.Add(tema);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateTema(Tema tema)
        {
            var currentTema = await GetTema(tema.Id);
            currentTema.Nombre = tema.Nombre;
            currentTema.Descripcion = tema.Descripcion;
            currentTema.Estado = tema.Estado;
            currentTema.IdCurso = tema.IdCurso;
            currentTema.FechaCreacion = tema.FechaCreacion;
            currentTema.FechaActualizacion = tema.FechaActualizacion;
            currentTema.Ponderacion = currentTema.Ponderacion;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteTema(long Id)
        {
            var currentTema = await GetTema(Id);
            _context.Tema.Remove(currentTema);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
