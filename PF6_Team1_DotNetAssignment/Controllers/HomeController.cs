using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PF6_Team1_DotNetAssignment.Core.Database;
using PF6_Team1_DotNetAssignment.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace PF6_Team1_DotNetAssignment.Controllers
{
    public class HomeController : Controller
    {
        public string str;
        private readonly ILogger<HomeController> _logger;
        private readonly Team1DbContext _context;

        public HomeController(Team1DbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {

            if (ModelState.IsValid)
            {



                //var f_password = GetMD5(password);
                var user = _context.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(password)).ToList();

                if (user.Count() == 1)
                {
                    //add session

                    TempData["data"] = user.FirstOrDefault().Username;
                    return RedirectToAction("After_login", new { id = user[0].UserId });

                    // return RedirectToAction("After_login/"+user[0].UserId);
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        [HttpGet("After_login/{id}")]
        public IActionResult After_login(int id)
        {
            TempData["id"] = id;
            Console.WriteLine(id);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
