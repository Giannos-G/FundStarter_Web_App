using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PF6_Team1_DotNetAssignment.Models;
using PF6_Team1_DotNetAssignment.Options;
using PF6_Team1_DotNetAssignment.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Controllers
{
    public class PackageController : Controller
    {

        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }


        // GET: PackageController
        public async Task<IActionResult> Index(int id)
        {
            var allPackagesResult = await _packageService.GetPackageByIdAsync(id);

            return View(allPackagesResult);
        }

        // GET: PackageController/Details/5
        public async Task<IActionResult> Details(int id, int id1)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var package = await _packageService.GetPackageAsync(id, id1);

            return View(package);
        }

        // GET: PackageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PackageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Price,Description,Reward")] Package package)
        {
            if (ModelState.IsValid)
            {
                await _packageService.CreatePackageAsync(new PackageOption
                { 
                    Title = package.Title,
                    Price = package.Price,
                    Description = package.Description,
                    Reward = package.Reward,
                    AmountOfBackers = package.AmountOfBackers
                });

                return RedirectToAction(nameof(Index));
            }

            return View(package);
        }

        // GET: PackageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PackageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PackageController/Delete/5
      /*  public ActionResult Delete(int id)
        {
            return View();
        }*/

        // POST: PackageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            await _packageService.DeletePackage(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
