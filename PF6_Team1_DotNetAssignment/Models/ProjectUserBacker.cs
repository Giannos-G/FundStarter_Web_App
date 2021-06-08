namespace PF6_Team1_DotNetAssignment.Models
{
    public class ProjectUserBacker
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public ProjectUserBacker(Project project, int userid)
        {
            //ProjectId = project.ProjectId;
            ////Project = project;
            //UserId = userid;
            ////User = user;
        }
        public ProjectUserBacker() { }
    }


}
