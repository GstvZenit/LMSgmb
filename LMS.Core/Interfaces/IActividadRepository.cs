using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface IActividadRepository
    {
        Task<IEnumerable<Actividad>> GetActividades();
        Task<Actividad> GetActividad(long Id);
        Task InsertActividad(Actividad actividad);
        Task<bool> UpdateActividad(Actividad actividad);
        Task<bool> DeleteActividad(long id);
    }
}
