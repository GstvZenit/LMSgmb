using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetUsuarios();
        Task<Usuario> GetUsuario(long Id);
        Task InsertUsuario(Usuario usuario);
        Task<Usuario> UpdateUsuario(Usuario usuario);
        Task<bool> DeleteUsuario(long id);
    }
}
