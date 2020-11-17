using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface IAdjuntoService
    {
        IEnumerable<Adjunto> GetAdjuntos();
        Task<Adjunto> GetAdjunto(long Id);
        Task InsertAdjunto(Adjunto adjunto);
        Task<Adjunto> UpdateAdjunto(Adjunto adjunto);
        Task<bool> DeleteAdjunto(long id);
    }
}
