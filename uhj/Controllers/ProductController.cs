using Microsoft.AspNetCore.Mvc;
using poe.Models;

namespace poe.Controllers
{
    public class ProductController : Controller
    {
        public productTable prodtbl = new productTable();



        [HttpPost]
        public ActionResult Index(productTable products)
        {
            var result2 = prodtbl.InsertProduct(products);
            return RedirectToAction("Mywork", "Home");
        }

        [HttpGet]
        public ActionResult MyWork()
        {
            return View(prodtbl);
        }
    }
}
