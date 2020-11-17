using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
using LMS.Core.Interfaces;
namespace LMS.Core.Services
{
    public class TemaService : ITemaService
    {
        //private readonly ITemaRepository _unitOfWork;
        private readonly IUnitOfWork _unitOfWork;
        public TemaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Tema> GetTema(long Id)
        {
            //return await _unitOfWork.GetTemao(Id);
            return await _unitOfWork.TemaRepository.GetById(Id);
        }
        public IEnumerable<Tema> GetTemas()
        {
            //return await _unitOfWork.GetTemaos();
            return _unitOfWork.TemaRepository.GetAll();
        }
        public async Task InsertTema(Tema tema)
        {
            //await _unitOfWork.InsertTema(producto);
            await _unitOfWork.TemaRepository.Add(tema);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Tema> UpdateTema(Tema tema)
        {
            //return await _unitOfWork.UpdateTema(producto);
            _unitOfWork.TemaRepository.Update(tema);
            await _unitOfWork.SaveChangesAsync();
            return tema;
        }
        public async Task<bool> DeleteTema(long Id)
        {
            //return await _unitOfWork.DeleteTema(Id);
            await _unitOfWork.TemaRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
