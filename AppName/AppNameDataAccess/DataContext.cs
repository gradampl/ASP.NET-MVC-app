﻿using AppName.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNameDataAccess
{
    public class DataContext:DbContext
    {
        public DataContext()
            :base("Name=DefaultConnection")
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
