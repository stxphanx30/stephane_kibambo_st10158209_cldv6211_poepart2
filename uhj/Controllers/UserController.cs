using Microsoft.AspNetCore.Mvc;
using poe.Models;

namespace poe.Controllers
{
    public class UserController : Controller
    {
        public UserTable UserTable = new UserTable();



        [HttpPost]
        public IActionResult SignUp(UserTable Users)
        {
            var result = UserTable.insert_User(Users);
            
            return RedirectToAction("Login","Home");
        }
        [HttpGet] 
        public IActionResult SignUp()
        { return View(UserTable);
        }

    }
}
