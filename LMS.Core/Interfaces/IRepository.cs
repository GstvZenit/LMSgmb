using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(long Id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(long Id);

    }
}
