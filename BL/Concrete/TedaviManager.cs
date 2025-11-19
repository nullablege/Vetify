using BL.Abstract;
using DAL.Abstract;
using EL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class TedaviManager : ITedaviService
    {
        private readonly ITedaviDal _tedaviDal;
        public TedaviManager(ITedaviDal tedaviDal)
        {
            _tedaviDal = tedaviDal;
        }
        public async Task AddAsync(Tedavi item)
        {
            await _tedaviDal.AddAsync(item);
            await _tedaviDal.SaveAsync();
        }

        public async Task<List<Tedavi>> GetAllAsync()
        {
            return await _tedaviDal.Query().ToListAsync();
        }

        public async Task<Tedavi> GetByIdAsync(int id)
        {
            return await _tedaviDal.GetByIdAsync(id);
        }

        public async Task<Tedavi> GetFirstAsync(Expression<Func<Tedavi, bool>> predivate)
        {
            return await _tedaviDal.FirstOrDefaultAsync(predivate);
        }

        public IQueryable<Tedavi> Query()
        {
            return _tedaviDal.Query();
        }

        public async Task RemoveAsync(Tedavi item)
        {
             _tedaviDal.Remove(item);
            await _tedaviDal.SaveAsync();
        }

        public async Task UpdateAsync(Tedavi item)
        {
            _tedaviDal.Update(item);
            await _tedaviDal.SaveAsync();
        }
    }
}
