using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface IAdjuntoRepository
    {
        Task<IEnumerable<Adjunto>> GetAdjuntos();
        Task<Adjunto> GetAdjunto(long Id);
        Task InsertAdjunto(Adjunto adjunto);
        Task<bool> UpdateAdjunto(Adjunto adjunto);
        Task<bool> DeleteAdjunto(long id);
    }
}
