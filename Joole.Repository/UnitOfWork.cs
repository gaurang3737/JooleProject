using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joole.DAL;
using Joole.Repository.Repositories;

namespace Joole.Repository
{
    public class UnitOfWork : IDisposable
    {
        DbContext Context;
        public IProductRepo products;
        public IUserRepo users;
        public IPropertyValueRepo propertyvalues;
        public IPropertyRepo properties;
        public IManufactureRepo manufactures;
        public ICategoryRepo categories;
        public ISubcategoryRepo subcategories;

        public UnitOfWork(DbContext context)
        {
            Context = context;
            products = new ProductRepo(context);
            users = new UserRepo(context);
            propertyvalues = new PropertyValueRepo(context);
            properties = new PropertyRepo(context);
            manufactures = new ManufactureRepo(context);
            categories = new CategoryRepo(context);
            subcategories = new SubcategoryRepo(context);
        }

        public void SaveChanges() {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
