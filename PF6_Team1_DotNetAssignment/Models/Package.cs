namespace PF6_Team1_DotNetAssignment.Models
{
    public class Package
    {
        public int PackageId { get; set; }
        public float Price { get; set; }            // decimal 
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reward { get; set; }
        //public int AmountOfBackers { get; set; }
        public int ProjectId { get; set; }
    }
}

