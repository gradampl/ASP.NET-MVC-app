using AppName.Logic.Interfaces;
using AppName.Logic.Repositories;
using AppName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppName.Logic.Products
{
    public class ProductLogic : IProductLogic
    {
        private IProductRepository _repository;

        public ProductLogic(IProductRepository repository)
        {
            _repository = repository;
        }

        public Result<Product> Create(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            //walidacja
            _repository.Add(product);
            _repository.SaveChanges();

            return Result.Ok(product);
        }

        public Result<IEnumerable<Product>> GetAllActive()
        {
            return Result.Ok(_repository.GetAllActive());
        }

        public Result<Product> GetById(int id)
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                return Result.Error<Product>($"Nie ma produktu o id {id}.");
            }
            return Result.Ok(product);
        }

        public Result<Product> Update(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            //walidacja
            
            _repository.SaveChanges();

            return Result.Ok(product);
        }
    }
}
