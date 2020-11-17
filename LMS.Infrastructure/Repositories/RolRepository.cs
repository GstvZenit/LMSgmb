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
    public class RolRepository : IRolRepository
    {
        private readonly LMS2Context _context;
        public RolRepository(LMS2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Rol>> GetRoles()
        {
            return await _context.Rol.ToArrayAsync();
        }
        public async Task<Rol> GetRol(long Id)
        {
            return await _context.Rol.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task InsertRol(Rol rol)
        {
            _context.Rol.Add(rol);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateRol(Rol rol)
        {
            var currentRol = await GetRol(rol.Id);
            currentRol.Nombre = rol.Nombre;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteRol(long Id)
        {
            var currentRol = await GetRol(Id);
            _context.Rol.Remove(currentRol);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
