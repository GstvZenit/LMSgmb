using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
using LMS.Core.Interfaces;
namespace LMS.Core.Services
{
    public class CursoService : ICursoService
    {
        //private readonly ICursoRepository _unitOfWork;
        private readonly IUnitOfWork _unitOfWork;
        public CursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Curso> GetCurso(long Id)
        {
            //return await _unitOfWork.GetCursoo(Id);
            return await _unitOfWork.CursoRepository.GetById(Id);
        }
        public IEnumerable<Curso> GetCursos()
        {
            //return await _unitOfWork.GetCursoos();
            return _unitOfWork.CursoRepository.GetAll();
        }
        public async Task InsertCurso(Curso curso)
        {
            //await _unitOfWork.InsertCurso(producto);
            await _unitOfWork.CursoRepository.Add(curso);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Curso> UpdateCurso(Curso curso)
        {
            //return await _unitOfWork.UpdateCurso(producto);
            _unitOfWork.CursoRepository.Update(curso);
            await _unitOfWork.SaveChangesAsync();
            return curso;
        }
        public async Task<bool> DeleteCurso(long Id)
        {
            //return await _unitOfWork.DeleteCurso(Id);
            await _unitOfWork.CursoRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
