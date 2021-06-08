using PF6_Team1_DotNetAssignment.Core.Models;
using System;
using System.Collections.Generic;

namespace PF6_Team1_DotNetAssignment.Core.Options
{
    public class ProjectOption
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }
        public string MyImage { get; set; }
        public string MyVideo { get; set; }
        public float RequiredFunds { get; set; }            //decimal
        public float CurrentFunds { get; set; }             //decimal
        public DateTime CreatedDate { get; set; }
        public DateTime Deadline { get; set; }
        public int AmountOfViews { get; set; }          // To be invesigated...........

        public ProjectOption() { }
        public ProjectOption(Project project)
        {
            if (project != null)
            {
                ProjectId = project.ProjectId;
                Title = project.Title;
                Description = project.Description;
                Category = project.Category;
                Country = project.Country;
                MyImage = project.MyImage;
                MyVideo = project.MyVideo;
                RequiredFunds = project.RequiredFunds;
                CurrentFunds = project.CurrentFunds;
                CreatedDate = project.CreatedDate;
                Deadline = project.Deadline;
            }
        }

        public Project GetProject()                     //????????????????????????????
        {
            return new Project
            {
               ProjectId = ProjectId,
                Title = Title,
                Description = Description,
                Category = Category,
                Country = Country,
                MyImage = MyImage,
                MyVideo = MyVideo,
                RequiredFunds = RequiredFunds,
                CurrentFunds = CurrentFunds,
                CreatedDate = CreatedDate,
                Deadline = Deadline

            };
        }
    }
}