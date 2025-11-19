using EL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IOdemeService
    {
        IQueryable<Odeme> Query();
        Task<Odeme> GetByIdAsync(int id);
        Task<Odeme> GetFirstAsync(Expression<Func<Odeme, bool>> predicate);
        Task<List<Odeme>> GetAllAsync();
        Task AddAsync(Odeme entity);
        Task UpdateAsync(Odeme entity);
        Task RemoveAsync(Odeme entity);
    }
}
