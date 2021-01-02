using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Joole.DAL;


namespace Joole.Repository.Repositories
{

    public interface IUserRepo : IRepsitory<tblUser> { 
    
    }

    public class UserRepo : BaseRepositroy<tblUser>, IUserRepo 
    {
        public UserRepo(DbContext context) : base(context)
        {

        }
    }
}
