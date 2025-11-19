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
    public class SaglikKaydiManager : ISaglikKaydiService
    {
        private readonly ISaglikKaydiDal _saglikKaydiDal;
        public SaglikKaydiManager(ISaglikKaydiDal saglikKaydiDal)
        {
            _saglikKaydiDal = saglikKaydiDal;
        }
        public async Task AddAsync(SaglikKaydi entity)
        {
            await _saglikKaydiDal.AddAsync(entity);
            await _saglikKaydiDal.SaveAsync();
        }

        public Task<List<SaglikKaydi>> GetAllAsync()
        {
            return _saglikKaydiDal.Query().ToListAsync();
        }

        public Task<SaglikKaydi> GetByIdAsync(int id)
        {
            return _saglikKaydiDal.GetByIdAsync(id);
        }

        public Task<SaglikKaydi> GetFirstAsync(Expression<Func<SaglikKaydi, bool>> predicate)
        {
            return _saglikKaydiDal.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<SaglikKaydi> Query()
        {
            return _saglikKaydiDal.Query();
        }

        public async Task RemoveAsync(SaglikKaydi entity)
        {
             _saglikKaydiDal.Remove(entity);
            await _saglikKaydiDal.SaveAsync();
        }

        public async Task UpdateAsync(SaglikKaydi entity)
        {
            _saglikKaydiDal.Update(entity);
            await _saglikKaydiDal.SaveAsync();
        }
    }
}
