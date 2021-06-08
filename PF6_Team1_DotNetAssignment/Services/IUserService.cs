using PF6_Team1_DotNetAssignment.Models;
using PF6_Team1_DotNetAssignment.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Services
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(UserOption userOption);
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync (int id);
        Task<User> UpdateUserByIdAsync (int id,UserOption userOption);
        Task<int> DeleteUserByIdAsync(int UserId);
        Task<List<Project>> GetAllMyProjectsAsync(int? UserId);
        Task<List<ProjectUserBacker>> GetAllMyBackedProjectsAsync(int? UserId);
       

        
    }
}
