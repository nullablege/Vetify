using BL.Abstract;
using DAL.Abstract;
using EL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class HayvanManager : IHayvanService
    {
        private readonly IHayvanDal _hayvanDal;
        public HayvanManager(IHayvanDal hayvanDal)
        {
            _hayvanDal = hayvanDal;
        }


        public async Task AddAsync(Hayvan entity)
        {
            await _hayvanDal.AddAsync(entity);
            await _hayvanDal.SaveAsync();
        }

        public async Task<List<Hayvan>> GetAllAsync()
        {
            return await _hayvanDal.Query().ToListAsync();
        }


        public async Task<Hayvan?> GetByIdAsync(int id)
        {
            return await _hayvanDal.GetByIdAsync(id);
        }

        public async Task<Hayvan?> GetFirstAsync(Expression<Func<Hayvan, bool>> predicate)
        {
            return await _hayvanDal.FirstOrDefaultAsync(predicate);
        }

        public async Task<int> HayvanSahibi(int id)
        {
            var hayvan = await _hayvanDal.GetByIdAsync(id);
            if(hayvan == null)
            {
                return 0;
            }
            else
            {
                return hayvan.SahipId;
            }

        }

        public IQueryable<Hayvan> Query()
        {
            return _hayvanDal.Query();
        }

        public async Task RemoveAsync(Hayvan entity)
        {
            _hayvanDal.Remove(entity);
            await _hayvanDal.SaveAsync();
        }

        public async Task UpdateAsync(Hayvan entity)
        {
            _hayvanDal.Update(entity);
            await _hayvanDal.SaveAsync();
        }
    }
}
