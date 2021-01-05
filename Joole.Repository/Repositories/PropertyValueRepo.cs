﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Joole.DAL;

namespace Joole.Repository.Repositories
{

    public interface IPropertyValueRepo : IRepsitory<tblPropertyValue>
    {
        // define sepcific methods
    }
    public class PropertyValueRepo : BaseRepositroy<tblPropertyValue>, IPropertyValueRepo
    {
        public PropertyValueRepo(DbContext context) : base(context)
        {

        }

        // implement methonds
    }
}


