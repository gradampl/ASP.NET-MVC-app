using AppName.Logic.Interfaces;
using AppName.Logic.Products;
using AppName.Models;
using AppName.Web.ViewModels.Products;
using AppNameDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppName.Web.Controllers
{
    public class ProductsController : Controller
    {
        private IProductLogic _logic;
        public ProductsController()
        {
            _logic = new ProductLogic(new ProductRepository(new DataContext()));
        }

        // GET: Products
        public ActionResult Index()
        {
            var result = _logic.GetAllActive();
            var viewModel = new IndexViewModel()
            {
                Items = result.Value.Select(p => new IndexItemViewModel()
                {
                    Id = p.Id,
                    Name = p.Name
                })
            };
            return View(viewModel);
        }
        public ActionResult Create()
        {
            return View("Product");
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View("Product", viewModel);
            }

            var product = new Product()
            {
                Name = viewModel.Name,
                Description = viewModel.Description
            };

            var result = _logic.Create(product);

            if (result.IsSuccess == false)
            {
                return View("Product", viewModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var result = _logic.GetById(id);
            if (result.IsSuccess == false)
            {
                //
            }

            var viewModel = new ProductViewModel()
            {
                Id = result.Value.Id,
                Name = result.Value.Name,
                Description = result.Value.Description
            };

            return View("Product", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View("Product", viewModel);
            }

            var productResult = _logic.GetById(viewModel.Id);

            if (productResult.IsSuccess == false)
            {
                //return View("Product", viewModel);
            }
            productResult.Value.Name = viewModel.Name;
            productResult.Value.Description = viewModel.Description;

            var result = _logic.Update(productResult.Value);
            if (result.IsSuccess == false)
            {
                return View("Product", viewModel);
            }
            return RedirectToAction("Index");
        }
    }

}