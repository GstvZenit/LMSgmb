using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
using LMS.Core.Interfaces;
namespace LMS.Core.Services
{
    public class ParametroService : IParametroService
    {
        //private readonly IParametroRepository _unitOfWork;
        private readonly IUnitOfWork _unitOfWork;
        public ParametroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Parametro> GetParametro(long Id)
        {
            //return await _unitOfWork.GetParametroo(Id);
            return await _unitOfWork.ParametroRepository.GetById(Id);
        }
        public IEnumerable<Parametro> GetParametros()
        {
            //return await _unitOfWork.GetParametroos();
            return _unitOfWork.ParametroRepository.GetAll();
        }
        public async Task InsertParametro(Parametro parametro)
        {
            //await _unitOfWork.InsertParametro(producto);
            await _unitOfWork.ParametroRepository.Add(parametro);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<Parametro> UpdateParametro(Parametro parametro)
        {
            //return await _unitOfWork.UpdateParametro(producto);
            _unitOfWork.ParametroRepository.Update(parametro);
            await _unitOfWork.SaveChangesAsync();
            return parametro;
        }
        public async Task<bool> DeleteParametro(long Id)
        {
            //return await _unitOfWork.DeleteParametro(Id);
            await _unitOfWork.ParametroRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
