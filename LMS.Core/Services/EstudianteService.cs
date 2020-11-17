using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
using LMS.Core.Interfaces;
namespace LMS.Core.Services
{
    public class EstudianteService : IEstudianteService
    {
        //private readonly IEstudianteRepository _unitOfWork;
        private readonly IUnitOfWork _unitOfWork;
        public EstudianteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Estudiante> GetEstudiante(long Id)
        {
            //return await _unitOfWork.GetEstudianteo(Id);
            return await _unitOfWork.EstudianteRepository.GetById(Id);
        }
        public IEnumerable<Estudiante> GetEstudiantes()
        {
            //return await _unitOfWork.GetEstudianteos();
            return _unitOfWork.EstudianteRepository.GetAll();
        }
        public async Task InsertEstudiante(Estudiante estudiante)
        {
            //await _unitOfWork.InsertEstudiante(producto);
            await _unitOfWork.EstudianteRepository.Add(estudiante);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Estudiante> UpdateEstudiante(Estudiante estudiante)
        {
            //return await _unitOfWork.UpdateEstudiante(producto);
            _unitOfWork.EstudianteRepository.Update(estudiante);
            await _unitOfWork.SaveChangesAsync();
            return estudiante;
        }
        public async Task<bool> DeleteEstudiante(long Id)
        {
            //return await _unitOfWork.DeleteEstudiante(Id);
            await _unitOfWork.EstudianteRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
