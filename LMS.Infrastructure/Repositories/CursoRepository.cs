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
    public class CursoRepository : ICursoRepository
    {
        private readonly LMS2Context _context;
        public CursoRepository(LMS2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Curso>> GetCursos()
        {
            return await _context.Curso.ToArrayAsync();
        }
        public async Task<Curso> GetCurso(long Id)
        {
            return await _context.Curso.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task InsertCurso(Curso curso)
        {
            _context.Curso.Add(curso);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCurso(Curso curso)
        {
            var currentCurso = await GetCurso(curso.Id);
            currentCurso.Nombre = curso.Nombre;
            currentCurso.Descripcion = curso.Descripcion;
            currentCurso.Estado = curso.Estado;
            currentCurso.IdInstructor = curso.IdInstructor;
            currentCurso.FechaCreacion = curso.FechaCreacion;
            currentCurso.FechaActualizacion = curso.FechaActualizacion;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteCurso(long Id)
        {
            var currentCurso = await GetCurso(Id);
            _context.Curso.Remove(currentCurso);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
