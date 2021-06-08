using Microsoft.AspNetCore.Mvc;
using PF6_Team1_DotNetAssignment.Models;
using PF6_Team1_DotNetAssignment.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PF6_Team1_DotNetAssignment.Services;
using Microsoft.AspNetCore.Http;

namespace PF6_Team1_DotNetAssignment.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;


        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetUsersAsync());
        }

        public IActionResult Create()
        {
            return View();
        }


        //[HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetUserByIdAsync(id.Value);

            if (user == null)
            {
                return NotFound();
            }
           var userId1 = HttpContext.Session.GetString("UserSession");
            TempData["id"] = userId1;
            return View(user);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId, FirstName, LastName," +
            "Username, Email, Password, Age, Gender, InitialFunds, RegistrationDate")] User user)
        {
            if (ModelState.IsValid)
            {

                await _userService.CreateUserAsync(new UserOption
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Username = user.Username,
                    Password = user.Password,
                    Age = user.Age,
                    Gender = user.Gender,
                    InitialFunds = user.InitialFunds,
                    RegistrationDate = user.RegistrationDate



                });

                return RedirectToAction("Login", "Home");
            }

            return View(user);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetUserByIdAsync(id.Value);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userService.DeleteUserByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            //Validationsss.....
            return View(new UserOption
            { // Mapping.........
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password
            });


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int userId, [Bind("UserId, FirstName, LastName," +
            "Email,Password,Username")] UserOption user)
        {
            await _userService.UpdateUserByIdAsync(userId, user);

            return RedirectToAction("Details", new { id = userId });
            //return RedirectToAction(nameof(Details));
        }
    }
}
