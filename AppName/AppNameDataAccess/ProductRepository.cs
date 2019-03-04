using AppName.Logic.Repositories;
using AppName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNameDataAccess
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext db) : base(db)
        {
        }

        public IEnumerable<Product> GetByName(string name)
        {
            return Db.Products.Where(p => p.Name.ToLower().Contains(name.ToLower()));
        }
    }
}
