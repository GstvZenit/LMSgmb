using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
using LMS.Core.Interfaces;
namespace LMS.Core.Services
{
    public class RolService : IRolService
    {
        //private readonly IRolRepository _unitOfWork;
        private readonly IUnitOfWork _unitOfWork;
        public RolService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Rol> GetRol(long Id)
        {
            //return await _unitOfWork.GetRolo(Id);
            return await _unitOfWork.RolRepository.GetById(Id);
        }
        public IEnumerable<Rol> GetRoles()
        {
            //return await _unitOfWork.GetRolos();
            return _unitOfWork.RolRepository.GetAll();
        }
        public async Task InsertRol(Rol rol)
        {
            //await _unitOfWork.InsertRol(producto);
            await _unitOfWork.RolRepository.Add(rol);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Rol> UpdateRol(Rol rol)
        {
            //return await _unitOfWork.UpdateRol(producto);
            _unitOfWork.RolRepository.Update(rol);
            await _unitOfWork.SaveChangesAsync();
            return rol;
        }
        public async Task<bool> DeleteRol(long Id)
        {
            //return await _unitOfWork.DeleteRol(Id);
            await _unitOfWork.RolRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
