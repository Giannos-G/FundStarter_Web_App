using PF6_Team1_DotNetAssignment.Models;
using System;

namespace PF6_Team1_DotNetAssignment.Options
{
    public class UserOption
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }

        public User GetUser()
        {
            return new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Username = Username,
                Password = Password,
                RegistrationDate = DateTime.Now
            };

        }
        public UserOption() { }
        public UserOption(User user)
        {
            if (user != null)
            {
                UserId = user.UserId;
                FirstName = user.FirstName;
                LastName = user.LastName;
                Email = user.Email;
                Username = user.Username;
                Password = user.Password;
                RegistrationDate = user.RegistrationDate;
            }
        }
    }
}

