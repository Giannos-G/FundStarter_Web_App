using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PF6_Team1_DotNetAssignment.Models;
using PF6_Team1_DotNetAssignment.Options;
using PF6_Team1_DotNetAssignment.Services;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Controllers
{
    public class PackageController : Controller
    {

        private readonly IPackageService _packageService;
        private readonly IProjectService _projectService;

        public PackageController(IPackageService packageService, IProjectService projectService)
        {
            _packageService = packageService;
            _projectService = projectService;
        }


        // GET: PackageController
        public async Task<IActionResult> Index(int projectId)      //paei stin details tou project 
        {
            var project = await _projectService.GetProjectByIdAsync(projectId);
            return View(project);
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
       [HttpGet("Create/{id}")]
        public ActionResult Create(int id)
        {
            TempData["id"] = id;
            return View();
        }

        // POST: PackageController/Create
        [HttpPost("Create/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("PackageId,Title,Price,Description,Reward")] Package package)
        {
            if (ModelState.IsValid)
            {
                await _packageService.CreatePackageAsync(new PackageOption
                { 
                    Title = package.Title,
                    Price = package.Price,
                    Description = package.Description,
                    Reward = package.Reward,
                    //AmountOfBackers = package.AmountOfBackers,
                    ProjectId = id
                });

                return RedirectToAction("Details", "Project", new { @id = id });
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

        public async Task<IActionResult> Update(int id, [Bind("Title,Price,Description,Reward")] PackageOption package)                            
        {
            await _packageService.UpdatePackageAsync(id, package);
            return RedirectToAction(nameof(Index));
        }
    }
}
