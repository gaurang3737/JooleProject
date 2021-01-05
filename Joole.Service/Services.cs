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
using Joole.Repository.Repositories;

namespace Joole.Service
{
    public class Services
    {
        public static readonly JooleDBEntities context = new JooleDBEntities();
        readonly UnitOfWork uow = new UnitOfWork(context);

        public Boolean Login(string username, string password) {

            var dataset = uow.users.GetAll();

            foreach (var item in dataset) {
                if ((item.User_Name.Equals(username) || item.User_Email.Equals(username)) && item.User_Password.Equals(password)) {
                    return true;
                }
            }
            return false;
        }

        public void Submit_User(string username, string email, string password, byte[] b)
        {
            var dataset = uow.users.GetAll();
            var count = dataset.Count()+1;
            tblUser user = new tblUser();
            user.User_ID = count;
            user.User_Name = username;
            user.User_Email = email;
            user.User_Password = password;
            user.User_Image = b;
            context.tblUsers.Add(user);
            context.SaveChanges();
        }


        public List<User> GetUserList() {

            var dataset = uow.users.GetAll();
            List<User> users = new List<User>();
            foreach (var item in dataset) {
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

        public List<List<List<string>>> GetProductList()
        {
            var dataset = uow.products.GetAll();
            var dataset1 = uow.manufactures.GetAll();
            var dataset2 = (from a in dataset join b in dataset1 on a.Manufacture_ID equals b.Manufacture_ID where a.Product_ID == 1
            select new
            { Product_name = a.Product_Name, Manufacture_name = b.Manufacture_Name, Series = a.Series, Model = a.Model
            }).ToList();

            var dataset3 = uow.propertyvalues.GetAll();
            var dataset4 = uow.properties.GetAll();

            var dataset5 = (from a in dataset
                            join b in dataset3 on a.Product_ID equals b.Product_ID
                            join c in dataset4 on b.Property_ID equals c.Property_ID
                            where a.Product_ID == 1 //&& c.Property_ID == 10
                            select new
                            { PropName = c.Property_Name, Type = c.IsType, Value = b.Value
                            }).ToList();
           


            List<List<List<string>>> result = new List<List<List<string>>>();
            List<List<string>> products = new List<List<string>>();
            foreach (var item in dataset2)
            {
                List<string> temp = new List<String>();
                temp.Add(item.Product_name);
                temp.Add(item.Manufacture_name);
                temp.Add(item.Series);
                temp.Add(item.Model);
                products.Add(temp);
            }

            result.Add(products);

            List<List<string>> istypes = new List<List<string>>();
            List<List<string>> istechspec = new List<List<string>>();
            foreach (var item in dataset5)
            {
                List<string> temp = new List<String>();
                if ((bool)item.Type)
                {
                    //istypes.Add(1.ToString());
                    temp.Add(item.PropName);
                    temp.Add(item.Value);
                    istypes.Add(temp);
                }
                else
                {
                    //istechspec.Add(0.ToString());
                    temp.Add(item.PropName);
                    temp.Add(item.Value);
                    istechspec.Add(temp);
                }
                
            }

            result.Add(istypes);
            result.Add(istechspec);





            /*
            var dataset = uow.products.GetAll();
            List<Product> products = new List<Product>();
            foreach (var item in dataset)
            {
                Product product = new Product();
                product.Pid = item.Product_ID;
                product.Mid = item.Manufacture_ID;
                product.Subcatid = item.SubCategory_ID;
                product.Name = item.Product_Name;
                product.Image = item.Product_Image;
                product.Series = item.Series;
                product.Model = item.Model;
                products.Add(product);

            }*/
            return result;
        }


    }

    //public class JooleContext : JooleDBEntities {
    //    public JooleContext() { 

    //    }
    //}
}
