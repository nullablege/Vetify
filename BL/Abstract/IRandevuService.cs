using EL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IRandevuService
    {
        IQueryable<Randevu> Query();
        Task<Randevu> GetByIdAsync(int id);
        Task<Randevu> GetFirstAsync(Expression<Func<Randevu, bool>> predicate);
        Task<List<Randevu>> GetAllAsync();
        Task AddAsyc(Randevu entity);
        Task RemoveAsync(Randevu entity);
        Task UpdateAsync(Randevu entity);
        Task<bool> RandevuIptal(int userId, int randevuId);

    }
}
