using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Joole.DAL;

namespace Joole.Repository.Repositories
{
    public interface ICategoryRepo : IRepsitory<tblCategory>
    {

    }
    public class CategoryRepo : BaseRepositroy<tblCategory>, ICategoryRepo
    {
        public CategoryRepo(DbContext context) : base(context)
        {

        }
    }
}
