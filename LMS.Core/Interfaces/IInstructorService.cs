using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface IInstructorService
    {
        IEnumerable<Instructor> GetInstructores();
        Task<Instructor> GetInstructor(long Id);
        Task InsertInstructor(Instructor instructor);
        Task<Instructor> UpdateInstructor(Instructor instructor);
        Task<bool> DeleteInstructor(long id);
    }
}
