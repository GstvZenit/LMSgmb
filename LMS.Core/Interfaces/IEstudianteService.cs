using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface IEstudianteService
    {
        IEnumerable<Estudiante> GetEstudiantes();
        Task<Estudiante> GetEstudiante(long Id);
        Task InsertEstudiante(Estudiante estudiante);
        Task<Estudiante> UpdateEstudiante(Estudiante estudiante);
        Task<bool> DeleteEstudiante(long id);
    }
}
