using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
   public interface ICategoryDal:IRepository<Category>
    {
        
    }
}
