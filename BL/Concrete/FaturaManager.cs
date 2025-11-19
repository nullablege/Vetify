using BL.Abstract;
using DAL;
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
    public class FaturaManager : IFaturaService
    {
        private readonly IFaturaDal _faturaDal;

        public FaturaManager(IFaturaDal faturaDal)
        {
            _faturaDal = faturaDal;
        }
        public async Task AddAsync(Fatura entity)
        {
            await _faturaDal.AddAsync(entity);
            await _faturaDal.SaveAsync();
        }

        public async Task<List<Fatura>> GetAllAsync()
        {
            return await _faturaDal.Query().ToListAsync();
        }

        public async Task<Fatura?> GetByIdAsync(int id)
        {
            return await _faturaDal.GetByIdAsync(id);
        }

        public async Task<Fatura?> GetFirstAsync(Expression<Func<Fatura, bool >> predicate)
        {
            return await _faturaDal.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<Fatura> Query()
        {
            return _faturaDal.Query();
        }

        public async Task RemoveAsync(Fatura entity)
        {
            _faturaDal.Remove(entity);
            await _faturaDal.SaveAsync();
        }

        public async Task UpdateAsync(Fatura entity)
        {
            _faturaDal.Update(entity);
            await _faturaDal.SaveAsync();
        }
    }
}
