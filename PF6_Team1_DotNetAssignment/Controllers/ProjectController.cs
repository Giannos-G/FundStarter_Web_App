using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PF6_Team1_DotNetAssignment.Models;
using PF6_Team1_DotNetAssignment.Options;
using PF6_Team1_DotNetAssignment.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;

        public ProjectController (IProjectService projectService, IUserService userService)
        {
            _projectService = projectService;
            _userService = userService;
        }
        
        // Get All Projects
        public async Task<IActionResult> Index()
        {
            return View(await _projectService.GetProjectsAsync());
        }
        // Get a single Project 
        public async Task<IActionResult> Details(int? id)           // id is Nullable
        {
            if (id == null)
            {
                return NotFound();
            }

            var append_to_projects = await _projectService.AppendPackageToProjectAsync(id.Value);

            var project = await _projectService.GetProjectByIdAsync(id.Value);

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }


        public async Task<IActionResult> Index_All()
        {
            return View(await _projectService.GetProjectsAsync());
        }

        //Create a Project 

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([FromForm] Project project)
        {
            var uniqueFileName = GetUniqueFileName(project.MyImage.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img", uniqueFileName);
            project.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));

            var userId1= HttpContext.Session.GetString("UserSession");
            if (ModelState.IsValid)
            {
                await _projectService.CreateProjectAsync(new ProjectOption
                {
                    Title = project.Title,                          // Mapping 
                    Description = project.Description,
                    Category = project.Category,
                    Country = project.Country,
                    FileName = uniqueFileName,
                    RequiredFunds = project.RequiredFunds,
                    CurrentFunds = project.CurrentFunds,
                    CreatedDate = project.CreatedDate,
                    Deadline = project.Deadline,
                    UserId= int.Parse(userId1)

                });

                return RedirectToAction("GetMyProjects", "Users", new {@id = userId1});
            }
            return View(project);
        }
        //Delete a Project 

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _projectService.GetProjectByIdAsync(id.Value);

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)        
        {
            await _projectService.DeleteProjectByIdAsync(id);
            var userId1 = HttpContext.Session.GetString("UserSession");
            return RedirectToAction("GetMyProjects", "Users", new { @id = userId1 });
        }

        // Update a Project .............................


        public async Task <IActionResult> Edit(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            //Validationsss.....
            return View(new ProjectOption { // Mapping.........
             ProjectId = project.ProjectId,
            Title = project.Title,
            Description = project.Description,
            Category = project.Category,
            Country = project.Country,
            //MyImage = project.MyImage,
            RequiredFunds = project.RequiredFunds,
            Deadline = project.Deadline
            });           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int projectId, [Bind("ProjectId, Title, Description," +
            "Category, Country, MyImage, RequiredFunds, Deadline")] ProjectOption project)                             
        {
            await _projectService.UpdateProjectById(projectId, project);
            return RedirectToAction("Details", "Project", new { @id = projectId });
        }

        public async Task<IActionResult> AddFunds(int id)
        {
            var userId1 = HttpContext.Session.GetString("UserSession");
            await _projectService.UpdateCurrentFunds(id, int.Parse(userId1));

            return RedirectToAction("Index", "Home");
        }
        private static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
            + "_"
            + Guid.NewGuid().ToString().Substring(0, 4)
            + Path.GetExtension(fileName);
        }
    }
}
