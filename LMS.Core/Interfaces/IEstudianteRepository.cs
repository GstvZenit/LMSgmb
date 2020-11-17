using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<IEnumerable<Estudiante>> GetEstudiantes();
        Task<Estudiante> GetEstudiante(long Id);
        Task InsertEstudiante(Estudiante estudiante);
        Task<bool> UpdateEstudiante(Estudiante estudiante);
        Task<bool> DeleteEstudiante(long id);
    }
}
