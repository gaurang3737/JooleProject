
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Joole.DAL;

namespace Joole.Repository.Repositories
{

    public interface IPropertyRepo : IRepsitory<tblProperty>
    {
        // define sepcific methods
    }
    public class PropertyRepo : BaseRepositroy<tblProperty>, IPropertyRepo
    {
        public PropertyRepo(DbContext context) : base(context)
        {

        }

        // implement methonds
    }
}