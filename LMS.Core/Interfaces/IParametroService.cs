using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface IParametroService
    {
        IEnumerable<Parametro> GetParametros();
        Task<Parametro> GetParametro(long Id);
        Task InsertParametro(Parametro parametro);
        Task<Parametro> UpdateParametro(Parametro parametro);
        Task<bool> DeleteParametro(long id);
    }
}
