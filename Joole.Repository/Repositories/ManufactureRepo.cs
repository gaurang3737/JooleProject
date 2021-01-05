using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Joole.DAL;

namespace Joole.Repository.Repositories
{

    public interface IManufactureRepo : IRepsitory<tblManufacture>
    {
        // define sepcific methods
    }
    public class ManufactureRepo : BaseRepositroy<tblManufacture>, IManufactureRepo
    {
        public ManufactureRepo(DbContext context) : base(context)
        {

        }

        // implement methonds
    }
}
