using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface IInscripcionService
    {
        IEnumerable<Inscripcion> GetInscripciones();
        Task<Inscripcion> GetInscripcion(long Id);
        Task InsertInscripcion(Inscripcion inscripcion);
        Task<Inscripcion> UpdateInscripcion(Inscripcion inscripcion);
        Task<bool> DeleteInscripcion(long id);
    }
}
