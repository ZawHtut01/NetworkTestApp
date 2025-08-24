using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using SampleMVC.Models;
using System.Text.Encodings.Web;

namespace SampleMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            var users = new List<User>()
            {
                new User(){Id = 1, Name= "Zaw Htut"},
                new User(){Id = 2, Name= "May Thet Paing"},
                new User(){Id = 3, Name= "Cherry"},
            };
            return View(users);
        }

        public IActionResult Test()
        {
            ViewData["user"] = new User()
            {
                Id = 1,
                Name = "Messi"
            };

            return View();
        }

        public IActionResult ViewDataTest()
        {
            ViewData["users"] = new List<User>()
            {
                new User(){Id = 1, Name= "Zaw Htut Aung"},
                new User(){Id = 2, Name= "May Thet Paing"},
                new User(){Id = 3, Name= "Cherry Wai Hlaing"},
            };

            return View();
        }

        public IActionResult ViewBagTest()
        {
            ViewBag.user = new User()
            {
                Id = 3,
                Name = "View Bag"
            };
            return View();
        }

        public IActionResult Detail(int id)
        {
            var users = new List<User>()
            {
                new User(){Id = 1, Name= "Zaw Htut"},
                new User(){Id = 2, Name= "May Thet Paing"},
                new User(){Id = 3, Name= "Cherry"},
            };

            var user = new User();
            foreach (var u in users)
            {
                if (u.Id == id)
                {
                    user.Id = u.Id;
                    user.Name = u.Name;

                    break;
                }
            }

            TempData["alertMessage"] = $"You are viewing detail of {user.Name}";

            return View(user);
        }

    }
}
