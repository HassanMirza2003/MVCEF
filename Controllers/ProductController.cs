using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCEF.Models;
using MVCEF.Models.Entities;

namespace MVCEF.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;
        // GET: ProductController
        public ProductController(ApplicationDbContext applicationDbContext)
        {
            this.context = applicationDbContext;
        }
        public ActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddProduct addProduct)
        {
            try
            {
                Product product = new Product();
                {
                    product.Name = addProduct.Name;
                    product.Description = addProduct.Description;
                    product.Price = addProduct.Price;

                };
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = context.Products.SingleOrDefault(p => p.Id == id);

            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                var dbProduct = context.Products.SingleOrDefault(p=>p.Id == product.Id);
                dbProduct.Name = product.Name;
                dbProduct.Description = product.Description;
                dbProduct.Price = product.Price;
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = context.Products.SingleOrDefault(p => p.Id == id);
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            try
            {
                var dbProduct = context.Products.SingleOrDefault(p => p.Id == product.Id);
                context.Products.Remove(dbProduct);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
