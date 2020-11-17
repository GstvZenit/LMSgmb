using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface IInstructorRepository
    {
        Task<IEnumerable<Instructor>> GetInstructores();
        Task<Instructor> GetInstructor(long Id);
        Task InsertInstructor(Instructor instructor);
        Task<bool> UpdateInstructor(Instructor instructor);
        Task<bool> DeleteInstructor(long id);
    }
}
