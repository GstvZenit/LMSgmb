using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
using LMS.Core.Interfaces;
namespace LMS.Core.Services
{
    public class InscripcionService : IInscripcionService
    {
        //private readonly IInscripcionRepository _unitOfWork;
        private readonly IUnitOfWork _unitOfWork;
        public InscripcionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Inscripcion> GetInscripcion(long Id)
        {
            //return await _unitOfWork.GetInscripciono(Id);
            return await _unitOfWork.InscripcionRepository.GetById(Id);
        }
        public IEnumerable<Inscripcion> GetInscripciones()
        {
            //return await _unitOfWork.GetInscripcionos();
            return _unitOfWork.InscripcionRepository.GetAll();
        }
        public async Task InsertInscripcion(Inscripcion inscripcion)
        {
            //await _unitOfWork.InsertInscripcion(producto);
            await _unitOfWork.InscripcionRepository.Add(inscripcion);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Inscripcion> UpdateInscripcion(Inscripcion inscripcion)
        {
            //return await _unitOfWork.UpdateInscripcion(producto);
            _unitOfWork.InscripcionRepository.Update(inscripcion);
            await _unitOfWork.SaveChangesAsync();
            return inscripcion;
        }
        public async Task<bool> DeleteInscripcion(long Id)
        {
            //return await _unitOfWork.DeleteInscripcion(Id);
            await _unitOfWork.InscripcionRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
