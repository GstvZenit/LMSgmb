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
    public class ParametroRepository : IParametroRepository
    {
        private readonly LMS2Context _context;
        public ParametroRepository(LMS2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Parametro>> GetParametros()
        {
            return await _context.Parametro.ToArrayAsync();
        }
        public async Task<Parametro> GetParametro(long Id)
        {
            return await _context.Parametro.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task InsertParametro(Parametro parametro)
        {
            _context.Parametro.Add(parametro);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateParametro(Parametro parametro)
        {
            var currentParametro = await GetParametro(parametro.Id);
            currentParametro.Nombre = parametro.Nombre;
            currentParametro.Valor = parametro.Valor;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteParametro(long Id)
        {
            var currentParametro = await GetParametro(Id);
            _context.Parametro.Remove(currentParametro);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
