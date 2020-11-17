using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
using LMS.Core.Interfaces;
namespace LMS.Core.Services
{
    public class ActividadService : IActividadService
    {
        //private readonly IActividadRepository _unitOfWork;
        private readonly IUnitOfWork _unitOfWork;
        public ActividadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Actividad> GetActividad(long Id)
        {
            //return await _unitOfWork.GetActividado(Id);
            return await _unitOfWork.ActividadRepository.GetById(Id);
        }
        public IEnumerable<Actividad> GetActividades()
        {
            //return await _unitOfWork.GetActividados();
            return _unitOfWork.ActividadRepository.GetAll();
        }
        public async Task InsertActividad(Actividad actividad)
        {
            //await _unitOfWork.InsertActividad(producto);
            await _unitOfWork.ActividadRepository.Add(actividad);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Actividad> UpdateActividad(Actividad actividad)
        {
            //return await _unitOfWork.UpdateActividad(producto);
            _unitOfWork.ActividadRepository.Update(actividad);
            await _unitOfWork.SaveChangesAsync();
            return actividad;
        }
        public async Task<bool> DeleteActividad(long Id)
        {
            //return await _unitOfWork.DeleteActividad(Id);
            await _unitOfWork.ActividadRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
