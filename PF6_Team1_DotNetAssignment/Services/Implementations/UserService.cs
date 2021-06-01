using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PF6_Team1_DotNetAssignment.Database;
using PF6_Team1_DotNetAssignment.Models;
using PF6_Team1_DotNetAssignment.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Services
{
    public class UserService : IUserService
    {
        private readonly Team1DbContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(Team1DbContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<User> CreateUserAsync(UserOption options)
        {
            var newUser = new User
            {
                UserId = options.UserId,
                FirstName = options.FirstName,
                LastName = options.LastName,
                Email = options.Email,
                Username = options.Username,
                Password = options.Password,
                RegistrationDate = options.RegistrationDate,
                CreatedProjects = options.CreatedProjects,
                BackedProjects = options.BackedProjects

            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser;

        }

        public async Task<int> DeleteUserByIdAsync(int id)
        {
            var UserToDelete = await GetUserByIdAsync(id);

            _context.Users.Remove(UserToDelete);

            return await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var UserToBeRead = await _context.Users.SingleOrDefaultAsync(u => u.UserId == id);

            return UserToBeRead;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> UpdateUserByIdAsync(int id, UserOption userOption)
        {
            var UserToUpdate = await GetUserByIdAsync(id);
            if (UserToUpdate == null)
            {
                return null;
            }

            UserToUpdate.FirstName = userOption.FirstName;
            UserToUpdate.LastName = userOption.LastName;
            UserToUpdate.Email = userOption.Email;
            UserToUpdate.Username = userOption.Username;
            UserToUpdate.Password = userOption.Password;
            UserToUpdate.RegistrationDate = userOption.RegistrationDate;
            UserToUpdate.CreatedProjects = userOption.CreatedProjects;
            UserToUpdate.BackedProjects = userOption.BackedProjects;

            await _context.SaveChangesAsync();
            return UserToUpdate;

        }

        //Get a list with backed projects!
        public async Task<List<Project>> GetAllMyBackedProjectsAsync(UserOption userOption)
        {
            if (userOption.BackedProjects == null)
            {
                _logger.LogError($"The user {userOption.LastName} does not have any backed projects yet!");
                return null;
            }

            await _context.Users.SingleOrDefaultAsync(user => user.UserId == userOption.UserId);
            return userOption.BackedProjects;
        }

        //Get a list with my created projects!
        public async Task<List<Project>> GetAllMyProjectsAsync(UserOption userOption)
        {
            if (userOption.CreatedProjects == null)
            {
                _logger.LogError($"The user {userOption.LastName} does not have any created projects yet!");
                return null;
            }

            await _context.Users.SingleOrDefaultAsync(user => user.UserId == userOption.UserId);
            return userOption.CreatedProjects;
        }
    }
}
