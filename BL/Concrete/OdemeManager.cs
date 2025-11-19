using BL.Abstract;
using DAL.Abstract;
using DAL.Concrete;
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
    public class OdemeManager : IOdemeService
    {
        private readonly IOdemeDal _odemeDal;
        public OdemeManager(IOdemeDal odemeDal)
        {
            _odemeDal = odemeDal;
        }
        public async Task AddAsync(Odeme entity)
        {
            await _odemeDal.AddAsync(entity);
            await _odemeDal.SaveAsync();
        }

        public async Task<List<Odeme>> GetAllAsync()
        {
            return await _odemeDal.Query().ToListAsync();
        }

        public async Task<Odeme> GetByIdAsync(int id)
        {
            return await _odemeDal.GetByIdAsync(id);
        }

        public async Task<Odeme> GetFirstAsync(Expression<Func<Odeme, bool>> predicate)
        {
            return await _odemeDal.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<Odeme> Query()
        {
            return _odemeDal.Query();
        }

        public async Task RemoveAsync(Odeme entity)
        {
            _odemeDal.Remove(entity);
            await _odemeDal.SaveAsync();
        }

        public async Task UpdateAsync(Odeme entity)
        {
            _odemeDal.Update(entity);
            await _odemeDal.SaveAsync();
        }
    }
}
