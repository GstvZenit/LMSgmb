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
    public class AdjuntoRepository : IAdjuntoRepository
    {
        private readonly LMS2Context _context;
        public AdjuntoRepository(LMS2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Adjunto>> GetAdjuntos()
        {
            return await _context.Adjunto.ToArrayAsync();
        }
        public async Task<Adjunto> GetAdjunto(long Id)
        {
            return await _context.Adjunto.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task InsertAdjunto(Adjunto adjunto)
        {
            _context.Adjunto.Add(adjunto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAdjunto(Adjunto adjunto)
        {
            var currentAdjunto = await GetAdjunto(adjunto.Id);
            currentAdjunto.Nombrearchivo = adjunto.Nombrearchivo;
            currentAdjunto.Ubicacion = adjunto.Ubicacion;
            currentAdjunto.IdRef = adjunto.IdRef;
            currentAdjunto.Tipo = adjunto.Tipo;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteAdjunto(long Id)
        {
            var currentAdjunto = await GetAdjunto(Id);
            _context.Adjunto.Remove(currentAdjunto);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
