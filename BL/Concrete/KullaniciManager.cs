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
    public class KullaniciManager : IKullaniciService
    {
        private readonly IKullaniciDal _kullaniciDal;
        public KullaniciManager(IKullaniciDal kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;
        }
        public async Task AddAsync(Kullanici entitiy)
        {
            await _kullaniciDal.AddAsync(entitiy);
            await _kullaniciDal.SaveAsync();
        }

        public async Task<List<Kullanici>> GetAllAsync()
        {
            return await _kullaniciDal.Query().ToListAsync();
        }

        public async Task<Kullanici?> GetByIdAsync(int id)
        {
            return await _kullaniciDal.GetByIdAsync(id);
        }

        public async Task<Kullanici?> GetFirstAsync(Expression<Func<Kullanici, bool>> predicate)
        {
            return await _kullaniciDal.FirstOrDefaultAsync(predicate);
        }

        public async Task UpdateAsync(Kullanici entitiy)
        {
            _kullaniciDal.Update(entitiy);
            await _kullaniciDal.SaveAsync();
        }

        public IQueryable<Kullanici> Quyery()
        {
            return _kullaniciDal.Query();
        }

        public async Task RemoveAsync(Kullanici entitiy)
        {
            _kullaniciDal.Remove(entitiy);
            await _kullaniciDal.SaveAsync();
        }
    }
}
