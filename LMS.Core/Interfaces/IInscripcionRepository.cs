using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface IInscripcionRepository
    {
        Task<IEnumerable<Inscripcion>> GetInscripciones();
        Task<Inscripcion> GetInscripcion(long Id);
        Task InsertInscripcion(Inscripcion inscripcion);
        Task<bool> UpdateInscripcion(Inscripcion inscripcion);
        Task<bool> DeleteInscripcion(long id);
    }
}
