using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface IControlasistenciaService
    {
        IEnumerable<Controlasistencia> GetControlasistencias();
        Task<Controlasistencia> GetControlasistencia(long Id);
        Task InsertControlasistencia(Controlasistencia controlasistencia);
        Task<Controlasistencia> UpdateControlasistencia(Controlasistencia controlasistencia);
        Task<bool> DeleteControlasistencia(long id);
    }
}
