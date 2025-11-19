using DAL.Abstract;
using DAL.Repositories;
using EL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class EfFaturaDal:EfRepository<Fatura>, IFaturaDal
    {
        public EfFaturaDal(Context context):base(context)
        {
            
        }
    }
}
