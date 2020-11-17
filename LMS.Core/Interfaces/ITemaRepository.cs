using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;

namespace LMS.Core.Interfaces
{
    public interface ITemaRepository
    {
        Task<IEnumerable<Tema>> GetTemas();
        Task<Tema> GetTema(long Id);
        Task InsertTema(Tema tema);
        Task<bool> UpdateTema(Tema tema);
        Task<bool> DeleteTema(long id);
    }
}
