using PF6_Team1_DotNetAssignment.Models;
using System;
using System.Collections.Generic;

namespace PF6_Team1_DotNetAssignment.Options
{
    public class CreateProjectOption
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }
        public string MyImage { get; set; }
        public string MyVideo { get; set; }
        public float RequiredFunds { get; set; }
        public float CurrentFunds { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Deadline { get; set; }
        public int AmountOfViews { get; set; }
    }
}
