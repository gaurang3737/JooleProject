using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joole.DAL;
using Joole.Repository;
using Joole.Service.Models;
using System.Data.Entity;
using System.Data;

namespace Joole.Service
{
    public class Services
    {
        public static readonly JooleDBEntities context = new JooleDBEntities();
        UnitOfWork uow = new UnitOfWork(context);

        public Boolean Login(string email, string password)
        {
            var dataset = uow.users.GetAll();
            foreach (var item in dataset)
            {
                if (item.User_Email.Equals(email) && item.User_Password.Equals(password))
                {
                    return true;
                }
            }
            return false;
        }

        public List<User> GetUserList()
        {

            var dataset = uow.users.GetAll();
            List<User> users = new List<User>();
            foreach (var item in dataset)
            {
                User user = new User();
                user.Id = item.User_ID;
                user.Name = item.User_Name;
                user.Email = item.User_Email;
                user.Password = item.User_Password;
                user.Image = item.User_Image;
                users.Add(user);

            }
            return users;
        }

        public List<Category> GetCategoryList()
        {
            var dataset = uow.categories.GetAll();
            List<Category> categories = new List<Category>();
            foreach (var item in dataset)
            {
                Category category = new Category();
                category.Id = item.Category_ID;
                category.Name = item.Category_Name;
                categories.Add(category);
            }
            return categories;
        }

        public List<SubCategory> GetSubCatByCatID(int categoryId)
        {
            var dataset = uow.subcategories.GetAll();
            List<SubCategory> subCategories = new List<SubCategory>();
            foreach (var item in dataset)
            {

                if (item.Category_ID == categoryId)
                {
                    SubCategory subCategory = new SubCategory();
                    subCategory.Id = item.SubCategory_ID;
                    subCategory.CategoryId = (int)item.Category_ID;
                    subCategory.Name = item.SubCategory_Name;
                    subCategories.Add(subCategory);
                }
            }
            return subCategories;
        }

    }

    //public class JooleContext : JooleDBEntities {
    //    public JooleContext() { 

    //    }
    //}
}
