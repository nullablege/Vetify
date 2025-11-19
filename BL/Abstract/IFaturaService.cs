using EL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IFaturaService
    {
        IQueryable<Fatura> Query();
        Task<List<Fatura>> GetAllAsync();
        Task<Fatura?> GetByIdAsync(int id);
        Task<Fatura?> GetFirstAsync(Expression<Func<Fatura, bool>> predicate);
        Task AddAsync(Fatura entity);
        Task RemoveAsync(Fatura entity);
        Task UpdateAsync(Fatura entity);
    }
}
