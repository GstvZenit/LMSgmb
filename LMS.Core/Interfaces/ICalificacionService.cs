using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface ICalificacionService
    {
        IEnumerable<Calificacion> GetCalificaciones();
        Task<Calificacion> GetCalificacion(long Id);
        Task InsertCalificacion(Calificacion calificacion);
        Task<Calificacion> UpdateCalificacion(Calificacion calificacion);
        Task<bool> DeleteCalificacion(long id);
    }
}
