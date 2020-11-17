using System;
using System.Collections.Generic;
using System.Text;
using LMS.Core.Entities;
using LMS.Core.Interfaces;
using LMS.Infrastructure.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly LMS2Context _context;
        public UsuarioRepository(LMS2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _context.Usuario.ToArrayAsync();
        }
        public async Task<Usuario> GetUsuario(long Id)
        {
            return await _context.Usuario.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task InsertUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            var currentUsuario = await GetUsuario(usuario.Id);
            currentUsuario.Nombre = usuario.Nombre;
            currentUsuario.Clave = usuario.Clave;
            currentUsuario.Estado = usuario.Estado;
            currentUsuario.Tipo = usuario.Tipo;
            currentUsuario.IdRef = usuario.IdRef;
            currentUsuario.IdRol = usuario.IdRol;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteUsuario(long Id)
        {
            var currentUsuario = await GetUsuario(Id);
            _context.Usuario.Remove(currentUsuario);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
