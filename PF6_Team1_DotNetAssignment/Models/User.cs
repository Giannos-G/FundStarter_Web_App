using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public decimal InitialFunds { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<Project> CreatedProjects { get; set; }
        public List<Project> BackedProjects { get; set; }

        private readonly List<Project> AllProjects = new();

        private readonly List<Project> AllBackedProjects = new();


    }
}

