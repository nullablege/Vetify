using EL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IKullaniciService
    {
        IQueryable<Kullanici> Quyery();
        Task<Kullanici?> GetByIdAsync(int id);
        Task<List<Kullanici>> GetAllAsync();
        Task<Kullanici?> GetFirstAsync(Expression<Func<Kullanici,bool>> predicate);
        Task AddAsync(Kullanici entitiy);
        Task UpdateAsync(Kullanici entitiy);
        Task RemoveAsync(Kullanici entitiy);


    }
}
