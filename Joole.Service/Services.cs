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

        //public List<Product> GetProductByID(int id)
        public int GetProductByID(int id)
        {
            var data = uow.products.GetAll();
            return data.Count();
        }
    }
}
