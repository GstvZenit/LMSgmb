using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface IRolRepository
    {
        Task<IEnumerable<Rol>> GetRoles();
        Task<Rol> GetRol(long Id);
        Task InsertRol(Rol rol);
        Task<bool> UpdateRol(Rol rol);
        Task<bool> DeleteRol(long id);
    }
}
