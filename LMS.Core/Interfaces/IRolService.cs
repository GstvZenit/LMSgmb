using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface IRolService
    {
        IEnumerable<Rol> GetRoles();
        Task<Rol> GetRol(long Id);
        Task InsertRol(Rol rol);
        Task<Rol> UpdateRol(Rol rol);
        Task<bool> DeleteRol(long id);
    }
}
