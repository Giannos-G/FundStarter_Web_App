using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }
        public List<Package> MyPackages { get; set; }
        public string MyImage { get; set; }
        public string MyVideo { get; set; }
        public decimal RequiredFunds { get; set; }
        public decimal CurrentFunds { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Deadline { get; set; }
        public int AmountOfViews { get; set; }


    }
}