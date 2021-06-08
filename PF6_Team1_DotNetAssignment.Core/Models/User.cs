using System;
using System.Collections.Generic;

namespace PF6_Team1_DotNetAssignment.Core.Models
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
        public float InitialFunds { get; set; }             // decimal
        public DateTime RegistrationDate { get; set; }
        public List<ProjectUserBacker> BackedProjects { get; set; }
        public List<Project> MyProjects { get; set; }

        //private readonly List<Project> AllProjects = new();             //need to be remove????????

        //private readonly List<Project> AllBackedProjects = new();


    }
}

