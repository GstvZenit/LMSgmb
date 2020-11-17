using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
using LMS.Core.Interfaces;
namespace LMS.Core.Services
{
    public class ControlasistenciaService : IControlasistenciaService
    {
        //private readonly IControlasistenciaRepository _unitOfWork;
        private readonly IUnitOfWork _unitOfWork;
        public ControlasistenciaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Controlasistencia> GetControlasistencia(long Id)
        {
            //return await _unitOfWork.GetControlasistenciao(Id);
            return await _unitOfWork.ControlasistenciaRepository.GetById(Id);
        }
        public IEnumerable<Controlasistencia> GetControlasistencias()
        {
            //return await _unitOfWork.GetControlasistenciaos();
            return _unitOfWork.ControlasistenciaRepository.GetAll();
        }
        public async Task InsertControlasistencia(Controlasistencia controlasistencia)
        {
            //await _unitOfWork.InsertControlasistencia(producto);
            await _unitOfWork.ControlasistenciaRepository.Add(controlasistencia);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Controlasistencia> UpdateControlasistencia(Controlasistencia controlasistencia)
        {
            //return await _unitOfWork.UpdateControlasistencia(producto);
            _unitOfWork.ControlasistenciaRepository.Update(controlasistencia);
            await _unitOfWork.SaveChangesAsync();
            return controlasistencia;
        }
        public async Task<bool> DeleteControlasistencia(long Id)
        {
            //return await _unitOfWork.DeleteControlasistencia(Id);
            await _unitOfWork.ControlasistenciaRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
