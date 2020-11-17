using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface ICursoService
    {
        IEnumerable<Curso> GetCursos();
        Task<Curso> GetCurso(long Id);
        Task InsertCurso(Curso curso);
        Task<Curso> UpdateCurso(Curso curso);
        Task<bool> DeleteCurso(long id);
    }
}
