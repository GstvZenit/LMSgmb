using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
using LMS.Core.Interfaces;
namespace LMS.Core.Services
{
    public class InstructorService : IInstructorService
    {
        //private readonly IInstructorRepository _unitOfWork;
        private readonly IUnitOfWork _unitOfWork;
        public InstructorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Instructor> GetInstructor(long Id)
        {
            //return await _unitOfWork.GetInstructoro(Id);
            return await _unitOfWork.InstructorRepository.GetById(Id);
        }
        public IEnumerable<Instructor> GetInstructores()
        {
            //return await _unitOfWork.GetInstructoros();
            return _unitOfWork.InstructorRepository.GetAll();
        }
        public async Task InsertInstructor(Instructor instructor)
        {
            //await _unitOfWork.InsertInstructor(producto);
            await _unitOfWork.InstructorRepository.Add(instructor);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Instructor> UpdateInstructor(Instructor instructor)
        {
            //return await _unitOfWork.UpdateInstructor(producto);
            _unitOfWork.InstructorRepository.Update(instructor);
            await _unitOfWork.SaveChangesAsync();
            return instructor;
        }
        public async Task<bool> DeleteInstructor(long Id)
        {
            //return await _unitOfWork.DeleteInstructor(Id);
            await _unitOfWork.InstructorRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
