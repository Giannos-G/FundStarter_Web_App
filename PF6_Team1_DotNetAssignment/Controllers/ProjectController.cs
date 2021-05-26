using Microsoft.AspNetCore.Mvc;
using PF6_Team1_DotNetAssignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController (IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _projectService.GetProjectsAsync());
        }

        public async Task<IActionResult> Details(int? id)           // id is Nullable
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
    }
}
