using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joole.DAL;

namespace Joole.Repository.Repositories
{
    public interface ISubcategoryRepo : IRepository<tblSubCategory>
    {
    }
    public class SubcategoryRepo : BaseRepositroy<tblSubCategory>, ISubcategoryRepo
    {
        public SubcategoryRepo(DbContext context) : base(context)
        {
        }
    }
}
