using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> GetCursos();
        Task<Curso> GetCurso(long Id);
        Task InsertCurso(Curso curso);
        Task<bool> UpdateCurso(Curso curso);
        Task<bool> DeleteCurso(long id);
    }
}
