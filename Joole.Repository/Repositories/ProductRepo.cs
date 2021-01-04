using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Joole.DAL;

namespace Joole.Repository.Repositories
{

    public interface IProductRepo : IRepsitory<tblProduct> {
        // define sepcific methods
        (IEnumerable<tblProduct>,List<String>) find_man(int id);
    }
    public class ProductRepo : BaseRepositroy<tblProduct>, IProductRepo
    {
        public ProductRepo(DbContext context) : base(context) {

        }

        // implement above specific methonds
        public (IEnumerable<tblProduct>, List<String>) find_man(int id)
        {
            List<String> man_list = new List<string>();
            var plist = Context.Set<tblProduct>().Where(e => e.SubCategory_ID == id).ToList();
            foreach(var p in plist)
            {
                string man_name = Context.Set<tblManufacture>().Find(p.Manufacture_ID).Manufacture_Name.ToString();
                man_list.Add(man_name);
            }
            return (plist, man_list);
        }
    }
}
