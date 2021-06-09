namespace PF6_Team1_DotNetAssignment.Models
{
    public class ProjectUserBacker
    {
        public int ProjectUserBackerId { get; set; }
        public int ProjectKey { get; set; }
        public Project Project { get; set; }
        public int UserKey { get; set; }
        public User User { get; set; }

        public ProjectUserBacker(Project project, int userid){}
        public ProjectUserBacker() { }
    }


}
