using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Joole.DAL;

namespace Joole.Repository.Repositories
{

    public interface IProductRepo : IRepsitory<Product> { 
        // define sepcific methods
    }
    public class ProductRepo : BaseRepositroy<Product>, IProductRepo
    {
        public ProductRepo(DbContext context) : base(context) { 
           
        }

        // implement methonds
    }
}
