using CRUD_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        //private List<Product> products = new List<Product>()
        //{
        //    new Product()
        //    {
        //        Id = 1,
        //        Name = "Apple",
        //        Price = 1000
        //    },
        //    new Product()
        //    {
        //        Id = 2,
        //        Name = "Huawei",
        //        Price = 2000
        //    },new Product()
        //    {
        //        Id = 3,
        //        Name = "Samsung",
        //        Price = 3000
        //    },
        //};

        private static List<Product> products = new List<Product>()
                {
                    new Product() { Id = 1, Name = "Apple", Price = 1000 },
                    new Product() { Id = 2, Name = "Huawei", Price = 2000 },
                    new Product() { Id = 3, Name = "Samsung", Price = 3000 },
                };
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if(products.Count > 0)
                {
                    product.Id = products.Max(x => x.Id) + 1;
                }
                else
                {
                    product.Id = 1;
                }
                    products.Add(product);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }


        public IActionResult Edit(int id)
        {
            var product = products.Where(x => x.Id == id).FirstOrDefault();
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var data = products.Where(x => x.Id == product.Id).FirstOrDefault();
                if (data == null) return NotFound();

                data.Name = product.Name;
                data.Price = product.Price;

                return RedirectToAction(nameof(Index));

            }
            return View(product);
        }


        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null) return NotFound();

            products.Remove(product);

            return RedirectToAction(nameof(Index));
        }

    }
}
