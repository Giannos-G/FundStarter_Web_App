using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PF6_Team1_DotNetAssignment.Database;
using PF6_Team1_DotNetAssignment.Models;
using PF6_Team1_DotNetAssignment.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Controllers
{
    public class HomeController : Controller
    {
        public string str;
        private readonly ILogger<HomeController> _logger;
        private readonly Team1DbContext _context;
        private readonly IProjectService _projectService;

        public HomeController(Team1DbContext context, ILogger<HomeController> logger, IProjectService projectService)
        {
            _context = context;
            _logger = logger;
            _projectService = projectService;
        }


        public async Task<IActionResult> Index()
        {
            //return View();
            return View(await _projectService.GetTrendingProject());
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

                var userId = new User();

                //var f_password = GetMD5(password);
                var user = _context.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(password)).ToList();
                

                if (user.Count() == 1)
                {
                    var idSes = user.FirstOrDefault().UserId;
                    HttpContext.Session.SetString("UserSession", idSes.ToString());
                    //add session

                    //TempData["data"] = user.FirstOrDefault().Username;
                    var user1 = HttpContext.Session.GetString("UserSession");

                    //return RedirectToAction(idSes.ToString(), "After_login");

                    return RedirectToAction("Index");
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

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
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
