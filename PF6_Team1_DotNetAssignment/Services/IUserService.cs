using PF6_Team1_DotNetAssignment.Models;
using PF6_Team1_DotNetAssignment.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Team1_dotNetAssignment.Service
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(UserOption userOption);
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync (int id);
        Task<User> UpdateUserByIdAsync (int id,UserOption userOption);
        Task<int> DeleteUserByIdAsync(int UserId);
        Task<List<Project>> GetAllMyProjectsAsync(UserOption userOption);
        Task<List<Project>> GetAllMyBackedProjectsAsync(UserOption userOption);

        
    }
}
