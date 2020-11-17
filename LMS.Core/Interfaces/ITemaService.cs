using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface ITemaService
    {
        IEnumerable<Tema> GetTemas();
        Task<Tema> GetTema(long Id);
        Task InsertTema(Tema tema);
        Task<Tema> UpdateTema(Tema tema);
        Task<bool> DeleteTema(long id);
    }
}
