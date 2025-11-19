using EL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface ISaglikKaydiService
    {
        IQueryable<SaglikKaydi> Query();
        Task<SaglikKaydi> GetByIdAsync(int id);
        Task<SaglikKaydi> GetFirstAsync(Expression<Func<SaglikKaydi, bool>> predicate);
        Task<List<SaglikKaydi>> GetAllAsync();
        Task RemoveAsync(SaglikKaydi entity);
        Task AddAsync(SaglikKaydi entity);
        Task UpdateAsync(SaglikKaydi entity);

    }
}
