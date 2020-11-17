using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
using LMS.Core.Interfaces;
namespace LMS.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        //private readonly IUsuarioRepository _unitOfWork;
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Usuario> GetUsuario(long Id)
        {
            //return await _unitOfWork.GetUsuarioo(Id);
            return await _unitOfWork.UsuarioRepository.GetById(Id);
        }
        public IEnumerable<Usuario> GetUsuarios()
        {
            //return await _unitOfWork.GetUsuarioos();
            return _unitOfWork.UsuarioRepository.GetAll();
        }
        public async Task InsertUsuario(Usuario usuario)
        {
            //await _unitOfWork.InsertUsuario(producto);
            await _unitOfWork.UsuarioRepository.Add(usuario);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            //return await _unitOfWork.UpdateUsuario(producto);
            _unitOfWork.UsuarioRepository.Update(usuario);
            await _unitOfWork.SaveChangesAsync();
            return usuario;
        }
        public async Task<bool> DeleteUsuario(long Id)
        {
            //return await _unitOfWork.DeleteUsuario(Id);
            await _unitOfWork.UsuarioRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
