using EL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IHayvanService
    {
        IQueryable<Hayvan> Query();
        Task<List<Hayvan>> GetAllAsync(); // Buna gerek yok aslında Query ıle de hallederız ama kalsın şimdilik
        Task<Hayvan?> GetByIdAsync(int id); // Buna gerek yok aslında Query ıle de hallederız ama kalsın şimdilik
        Task<Hayvan?> GetFirstAsync(Expression<Func<Hayvan, bool>> predicate); // Buna gerek yok aslında Query ıle de hallederız ama kalsın şimdilik
        Task AddAsync(Hayvan entity);
        Task UpdateAsync(Hayvan entity);
        Task RemoveAsync(Hayvan entity);
        Task<int> HayvanSahibi(int id);
    }
}
