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
        (IEnumerable<tblProduct>,List<String>, List<List<String>>) FindAllProducts(int sub_category_id);
    }
    public class ProductRepo : BaseRepositroy<tblProduct>, IProductRepo
    {
        public ProductRepo(DbContext context) : base(context) {

        }

        // implement above specific methonds
        public (IEnumerable<tblProduct>, List<String>, List<List<String>>) FindAllProducts(int sub_category_id)
        {
            List<String> man_list = new List<string>();
            List<List<String>> prop_value_list = new List<List<string>>();
            var plist = Context.Set<tblProduct>().Where(e => e.SubCategory_ID == sub_category_id).ToList();
            
            //Needed for finding filters
            var tech_spec_filter_data = Context.Set<tblTechSpecFilter>().Where(e => e.SubCategory_ID == sub_category_id).ToList();
            foreach (var p in plist)
            {
                //Extracting Manufacture Name
                string man_name = Context.Set<tblManufacture>().Find(p.Manufacture_ID).Manufacture_Name.ToString();
                man_list.Add(man_name);

                //Extracting Property Values
                var prop_values = Context.Set<tblPropertyValue>().Where(e => e.Product_ID == p.Product_ID).ToList();
                var props_data = Context.Set<tblProperty>().ToList();
                
                //Joining 2 tables
                var join_data = (from a in tech_spec_filter_data
                                 join b in prop_values on a.Property_ID equals b.Property_ID
                                 join c in props_data on b.Property_ID equals c.Property_ID
                                 select new
                                 {
                                     prop_name = c.Property_Name,
                                     prop_value = b.Value
                                 }).ToList();
                
                //Adding Properties into list of string
                List<String> product_prop = new List<string>();
                foreach(var prop in join_data)
                {
                    product_prop.Add(prop.prop_name +":" + prop.prop_value);
                }
                prop_value_list.Add(product_prop);
            }
            return (plist, man_list, prop_value_list);
        }
    }
}
