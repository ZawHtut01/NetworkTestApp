using CRUD_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_MVC.Controllers
{
    public class AccountController : Controller
    {
        public static List<Account> accounts = new List<Account>()
        {
            new Account()
            {
                Id = 1,
                Name = "Zaw Htut",
                Email = "zaw@gmail.com"
            },
            new Account()
            {
                Id = 2,
                Name = "May Thet",
                Email = "may@gmail.com"
            },
            new Account()
            {
                Id = 3,
                Name = "Cherry",
                Email = "cherry@gmail.com"
            }
        };
        public IActionResult Index()
        {
            return View(accounts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {
                var id = accounts.Count > 1 ? accounts.Max(x => x.Id) + 1 : 1;

                account.Id = id;

                accounts.Add(account);
                return RedirectToAction(nameof(Index));
            }

            return View(account);
        }

        public IActionResult Edit(int id)
        {
            var account = accounts.FirstOrDefault(x => x.Id == id);
            return View(account);
        }

        [HttpPost]
        public IActionResult Edit(Account account)
        {
            if (ModelState.IsValid)
            {
                var data = accounts.FirstOrDefault(x => x.Id == account.Id);
                if (data == null) return NotFound();

                data.Name = account.Name;
                data.Email = account.Email;

                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }
        public IActionResult Delete(int id)
        {
            var account = accounts.FirstOrDefault(x => x.Id == id);
            if (account == null) return NotFound();
            accounts.Remove(account);
            return RedirectToAction(nameof(Index));
        }

    }
}
