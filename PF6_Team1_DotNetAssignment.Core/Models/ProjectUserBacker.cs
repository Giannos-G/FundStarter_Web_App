namespace PF6_Team1_DotNetAssignment.Core.Models
{
    public class ProjectUserBacker
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
