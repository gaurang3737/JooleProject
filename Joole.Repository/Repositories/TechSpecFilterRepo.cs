using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joole.DAL;

namespace Joole.Repository.Repositories
{
    public interface ITechSpecFilter : IRepsitory<tblTechSpecFilter>
    {
        List<String> GetTechSpecFilters(int sub_id);
    }
    public class TechSpecFilterRepo : BaseRepositroy<tblTechSpecFilter>, ITechSpecFilter
    {
        public TechSpecFilterRepo(DbContext context) : base(context)
        {
        }

        public List<String> GetTechSpecFilters(int sub_id)
        {
            List<String> return_data = new List<string>();

            var tech_spec_filter_data = Context.Set<tblTechSpecFilter>().Where(e => e.SubCategory_ID == sub_id).ToList();
            var props_data = Context.Set<tblProperty>().ToList(); //Needed for "Property Name"

            //Joining 2 tables
            var join_data = (from a in tech_spec_filter_data
                             join b in props_data on a.Property_ID equals b.Property_ID
                             select new
                             {
                                 prop_name = b.Property_Name,
                                 min_value = a.Min_Value,
                                 max_value = a.Max_Value
                             }).ToList();

            //Creating List of String
            foreach(var row in join_data)
            {
                var r = row.prop_name.ToString() +":"+row.min_value.ToString() +":"+row.max_value.ToString();
                return_data.Add(r);
            }

            return return_data;
        }
    }
}
