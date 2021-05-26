using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PF6_Team1_DotNetAssignment.Database;
using PF6_Team1_DotNetAssignment.Models;
using PF6_Team1_DotNetAssignment.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly Team1DbContext _context;
        private readonly ILogger<ProjectService> _logger;

        //private readonly IProductValidation _productValidator;

        public ProjectService (Team1DbContext context, ILogger<ProjectService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Project> CreateProjectAsync(ProjectOption options)
        {
            // Validations.........................
            if (options == null)
            {
                _logger.LogError("Null options");
                return null;
            }
            if (options.Title == null)
            {
                _logger.LogError("Please specify a Title");
                return null;
            }
            if (options.RequiredFunds == 0)
            {
                _logger.LogError("Please specify the required funds for your project");
                return null;
            }
            if (options.Deadline == default)
            {
                _logger.LogError("Please specify a correct deadline for your project");
                return null;
            }

            // Find the project with the same title..................... 
            var ProjectWithSameTitle = await _context.Projects.SingleOrDefaultAsync(proj => proj.Title == options.Title);
            if (ProjectWithSameTitle != null)
            {
                _logger.LogError($" Project with title {options.Title} already exists");
                return null;
            }

            // Create the new project 
            var newProject = new Project
            {
                Title = options.Title,
                Description = options.Description,
                Category = options.Category,
                Country = options.Country,
                MyPackages = options.MyPackages,
                MyImage = options.MyImage,
                MyVideo = options.MyVideo,
                RequiredFunds = options.RequiredFunds,
                CurrentFunds = options.CurrentFunds,
                CreatedDate = options.CreatedDate,
                Deadline = options.Deadline,
                AmountOfViews = options.AmountOfViews
            };

            // Save and Update Db
            await _context.Projects.AddAsync(newProject);
            await _context.SaveChangesAsync();
            return newProject;
        }

        public async Task<int> DeleteProjectByIdAsync(int id)
        {
            //Validation..................
            if (id <= 0)
            {
                _logger.LogError("Id invalid! Id cannot be equal or less than zero");
                return -1;
            }

            // Find Project
            var ProjectToDelete = await GetProjectByIdAsync(id);        //Reusability
            if (ProjectToDelete == null)
            {
                return -1;
            }

            //Delete Project 
            _context.Projects.Remove(ProjectToDelete);
            // Update DB
            return await _context.SaveChangesAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            //Validation..................
            if (id <= 0)
            {
                _logger.LogError("Id invalid! Id cannot be equal or less than zero");
                return null;
            }
            //Find the project
            var ProjectToBeRead = await _context.Projects.SingleOrDefaultAsync(p => p.ProjectId == id);

            if (ProjectToBeRead == null)
            {
                _logger.LogError("Project does not exist");
                return null;
            }

            return ProjectToBeRead;

        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            return await _context.Projects.ToListAsync(); 
        }

        public async Task<Project> UpdateProjectById(int id, ProjectOption projectOption)
        {
            var ProjectToUpdate = await GetProjectByIdAsync(id);        //Reusability
            if (ProjectToUpdate == null)
            {
                return null;
            }
            
            // Update the project
            ProjectToUpdate.Title = projectOption.Title;
            ProjectToUpdate.Description = projectOption.Description;
            ProjectToUpdate.Category = projectOption.Category;
            ProjectToUpdate.Country = projectOption.Country;
            ProjectToUpdate.MyPackages = projectOption.MyPackages;
            ProjectToUpdate.MyImage = projectOption.MyImage;
            ProjectToUpdate.MyVideo = projectOption.MyVideo;
            ProjectToUpdate.RequiredFunds = projectOption.RequiredFunds;
            ProjectToUpdate.CurrentFunds = projectOption.CurrentFunds;
            ProjectToUpdate.CreatedDate = projectOption.CreatedDate;
            ProjectToUpdate.Deadline = projectOption.Deadline;
            ProjectToUpdate.AmountOfViews = projectOption.AmountOfViews;        //?????????????????????
            
            // Save and Update Db
            await _context.SaveChangesAsync();
            return ProjectToUpdate;
        }
    }
}
