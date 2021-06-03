using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Models
{
    public class Package
    {
        public int PackageId { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reward { get; set; }
        public int AmountOfBackers { get; set; }

    }
}

