using PF6_Team1_DotNetAssignment.Models;
using PF6_Team1_DotNetAssignment.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Services
{
    public interface IProjectService
    {
        // Create
        Task<Project> CreateProjectAsync(ProjectOption options);
        
        // Read
        Task<List<Project>> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        //Task<Project> GetProjectByTitleAsync(string title);

        //Update
        Task<Project> UpdateProjectById(int id, ProjectOption projectOption);
        
        //Delete
        Task<int> DeleteProjectByIdAsync(int id);

        Task<float> GetCurrentProgressAsync(ProjectOption projectOption);

    }
}
