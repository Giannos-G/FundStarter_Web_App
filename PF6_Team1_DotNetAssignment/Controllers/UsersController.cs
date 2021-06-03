using Microsoft.AspNetCore.Mvc;
using PF6_Team1_DotNetAssignment.Models;
using PF6_Team1_DotNetAssignment.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team1_dotNetAssignment.Service;

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

            return View(user);
        }

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
                    RegistrationDate = user.RegistrationDate
                });

                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        public async Task<IActionResult> Delete (int? id)
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


        public async Task<IActionResult> Update(int id, [Bind("UserId, FirstName, LastName," +
            "Username, Email, Password, Age, Gender, InitialFunds, RegistrationDate")] UserOption user)
        {
            await _userService.UpdateUserByIdAsync(id, user);
            return RedirectToAction(nameof(Index));
        }
    }
}
