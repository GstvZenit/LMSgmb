using System;
using System.Collections.Generic;
using System.Text;
using LMS.Core.Interfaces;
using LMS.Core.Entities;
using System.Threading.Tasks;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace LMS.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        //private readonly VentasUCBContext _context;
        private DbSet<T> _entities;

        public BaseRepository(LMS2Context context)
        {
            //_context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(long Id)
        {
            return await _entities.FindAsync(Id);
        }
        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(long Id)
        {
            var entity = await GetById(Id);
            _entities.Remove(entity);

        }






    }
}
