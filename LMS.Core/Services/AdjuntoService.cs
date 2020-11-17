using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
using LMS.Core.Interfaces;
namespace LMS.Core.Services
{
    public class AdjuntoService : IAdjuntoService
    {
        //private readonly IAdjuntoRepository _unitOfWork;
        private readonly IUnitOfWork _unitOfWork;
        public AdjuntoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Adjunto> GetAdjunto(long Id)
        {
            //return await _unitOfWork.GetAdjuntoo(Id);
            return await _unitOfWork.AdjuntoRepository.GetById(Id);
        }
        public IEnumerable<Adjunto> GetAdjuntos()
        {
            //return await _unitOfWork.GetAdjuntoos();
            return _unitOfWork.AdjuntoRepository.GetAll();
        }
        public async Task InsertAdjunto(Adjunto adjunto)
        {
            //await _unitOfWork.InsertAdjunto(producto);
            await _unitOfWork.AdjuntoRepository.Add(adjunto);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Adjunto> UpdateAdjunto(Adjunto adjunto)
        {
            //return await _unitOfWork.UpdateAdjunto(producto);
            _unitOfWork.AdjuntoRepository.Update(adjunto);
            await _unitOfWork.SaveChangesAsync();
            return adjunto;
        }
        public async Task<bool> DeleteAdjunto(long Id)
        {
            //return await _unitOfWork.DeleteAdjunto(Id);
            await _unitOfWork.AdjuntoRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
