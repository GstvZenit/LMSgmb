using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
using LMS.Core.Interfaces;
namespace LMS.Core.Services
{
    public class CalificacionService : ICalificacionService
    {
        //private readonly ICalificacionRepository _unitOfWork;
        private readonly IUnitOfWork _unitOfWork;
        public CalificacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Calificacion> GetCalificacion(long Id)
        {
            //return await _unitOfWork.GetCalificaciono(Id);
            return await _unitOfWork.CalificacionRepository.GetById(Id);
        }
        public IEnumerable<Calificacion> GetCalificaciones()
        {
            //return await _unitOfWork.GetCalificacionos();
            return _unitOfWork.CalificacionRepository.GetAll();
        }
        public async Task InsertCalificacion(Calificacion calificacion)
        {
            //await _unitOfWork.InsertCalificacion(producto);
            await _unitOfWork.CalificacionRepository.Add(calificacion);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Calificacion> UpdateCalificacion(Calificacion calificacion)
        {
            //return await _unitOfWork.UpdateCalificacion(producto);
            _unitOfWork.CalificacionRepository.Update(calificacion);
            await _unitOfWork.SaveChangesAsync();
            return calificacion;
        }
        public async Task<bool> DeleteCalificacion(long Id)
        {
            //return await _unitOfWork.DeleteCalificacion(Id);
            await _unitOfWork.CalificacionRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
