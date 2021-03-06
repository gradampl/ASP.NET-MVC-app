﻿using AppName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppName.Logic.Interfaces
{
    public interface IProductLogic: ILogic
    {
        Result<Product> GetById(int id);
        Result<Product> Create(Product product);
        Result<Product> Update(Product product);
        Result<IEnumerable<Product>> GetAllActive();
    }
}
