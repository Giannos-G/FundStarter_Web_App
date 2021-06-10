using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PF6_Team1_DotNetAssignment.Database;
using PF6_Team1_DotNetAssignment.Models;
using PF6_Team1_DotNetAssignment.Options;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Age = options.Age,
                Gender = options.Gender,
                Password = options.Password,
                //InitialFunds = options.InitialFunds,
                RegistrationDate = DateTime.Now
            };
            var UserWithSameEmail = await _context.Users.SingleOrDefaultAsync(user => user.Email == options.Email);
            if (UserWithSameEmail != null)
            {
                _logger.LogError($" User with email: {options.Email} already exists");
                return null;
            }

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

            await _context.SaveChangesAsync();
            return UserToUpdate;

        }

        //Get a list with backed projects!
        //na doume an o endiamesos pinakas mporei na mas dwsei th lista
        public async Task<List<Project>> GetAllMyBackedProjectsAsync(int? UserId)
        {
            if (UserId == null)
            {
                _logger.LogError($"The user {UserId} does not exist!");
                return null;
            }

            var myUser = await GetUserByIdAsync(UserId.Value);

            if (myUser.BackedProjects == null)
            {
                _logger.LogError($"The user {myUser.LastName} does not have any backed projects yet!");
                return null;
            }

            return await _context.ProjectUserBackers.Where(p => p.User.UserId == UserId).Select(p => p.Project).ToListAsync();
            //return myUser.BackedProjects;
        }

        public async Task<List<Project>> GetAllMyProjectsAsync(int? UserId)
        {
            return await _context.Projects.Where(p => p.UserId == UserId).ToListAsync(); 
        }

    }
}
