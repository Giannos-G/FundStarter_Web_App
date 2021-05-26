using PF6_Team1_DotNetAssignment.Models;
using PF6_Team1_DotNetAssignment.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Services
{
    interface IProjectService
    {
        // Create
        Task<Project> CreateProjectAsync(CreateProjectOption options);
        
        // Read
        Task<List<Project>> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);

        //Update
        Task<Project> UpdateProjectById(int id, ProjectOption projectOption);
        
        //Delete
        Task<int> DeleteProjectByIdAsync(int id);

    }
}
