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
    public class RandevuManager : IRandevuService
    {
        private readonly IRandevuDal _randevuDal;
        public RandevuManager(IRandevuDal randevuDal)
        {
            _randevuDal = randevuDal;
        }
        public async Task AddAsyc(Randevu entity)
        {
            await _randevuDal.AddAsync(entity);
            await _randevuDal.SaveAsync();
        }

        public async Task<List<Randevu>> GetAllAsync()
        {
            return await _randevuDal.Query().ToListAsync();
        }

        public async Task<Randevu> GetByIdAsync(int id)
        {
            return await _randevuDal.GetByIdAsync(id);
        }

        public async Task<Randevu> GetFirstAsync(Expression<Func<Randevu, bool>> predicate)
        {
            return await _randevuDal.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<Randevu> Query()
        {
            return _randevuDal.Query();
        }

        public async Task<bool> RandevuIptal(int userId, int randevuId)
        {
            var randevu = await GetByIdAsync(randevuId);
            if(randevu == null || randevu.MusteriId != userId)
                return false;

            randevu.Durum = EL.Enums.RandevuDurum.IptalEdildi;
            _randevuDal.Update(randevu);
            await _randevuDal.SaveAsync();
            return true;
                
        }

        public async Task RemoveAsync(Randevu entity)
        {
            _randevuDal.Remove(entity);
            await _randevuDal.SaveAsync();
        }

        public async Task UpdateAsync(Randevu entity)
        {
            _randevuDal.Update(entity);
            await _randevuDal.SaveAsync();
        }
    }
}
