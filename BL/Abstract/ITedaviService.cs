using EL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface ITedaviService
    {
        IQueryable<Tedavi> Query();
        Task<Tedavi> GetByIdAsync(int id);
        Task<Tedavi> GetFirstAsync(Expression<Func<Tedavi, bool>> predivate);
        Task<List<Tedavi>> GetAllAsync();
        Task AddAsync(Tedavi item);
        Task RemoveAsync(Tedavi item);
        Task UpdateAsync(Tedavi item);
    }
}
