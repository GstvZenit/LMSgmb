using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface IControlasistenciaRepository
    {
        Task<IEnumerable<Controlasistencia>> GetControlasistencias();
        Task<Controlasistencia> GetControlasistencia(long Id);
        Task InsertControlasistencia(Controlasistencia controlasistencia);
        Task<bool> UpdateControlasistencia(Controlasistencia controlasistencia);
        Task<bool> DeleteControlasistencia(long id);
    }
}
