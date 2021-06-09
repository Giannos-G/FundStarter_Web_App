﻿using System;
using System.Collections.Generic;

namespace PF6_Team1_DotNetAssignment.Models
{
    public class Project
    {
      
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }             // enumerate
        public List<Package> MyPackages { get; set; } = new List<Package>();
        public List<ProjectUserBacker> UserBackerList { get; set; } = new List<ProjectUserBacker>();
        public string MyImage { get; set; }
        //public string MyVideo { get; set; }
        public float RequiredFunds { get; set; }            // decimal
        public float CurrentFunds { get; set; }             // decimal
        public DateTime CreatedDate { get; set; }
        public DateTime Deadline { get; set; }
        //public int AmountOfViews { get; set; }
        public int UserId { get; set; }
    }
}