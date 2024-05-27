using Microsoft.AspNetCore.Mvc;
using poe.Models;
using System.Diagnostics;
using uhj.Models;

namespace uhj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult LoginFailed()
        {
            return View();
        }
        public IActionResult OrderFailed()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }
        public IActionResult ThankYou()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }


        public IActionResult MyWork(int userID)
        {
            List<productTable> products = productTable.GetAllProducts();

        


            // Pass products and userID to the view
            ViewData["products"] = products;
            ViewData["userID"] = userID;

            return View("MyWork");
        }
        public IActionResult History(int userID)
        {
            List<productTable> products = productTable.GetAllProducts();

           

            // Pass products and userID to the view
            ViewData["products"] = products;
            ViewData["userID"] = userID;

            return View("MyWork");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
