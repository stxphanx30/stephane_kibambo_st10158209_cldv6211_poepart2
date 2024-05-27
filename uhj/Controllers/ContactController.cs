using Microsoft.AspNetCore.Mvc;
using poe.Models;

namespace poe.Controllers
{
    public class ContactController : Controller
    {
        public ContactTable ContactTable = new ContactTable();



        [HttpPost]
        public IActionResult Contact(ContactTable Users)
        {
            var result = ContactTable.insert_User_caontact(Users);

            return RedirectToAction("ThankYou", "Home");
        }
        [HttpGet]
        public IActionResult Contatc()
        {
            return View(ContactTable);
        }

    }
}