using Microsoft.AspNetCore.Http;
using PF6_Team1_DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PF6_Team1_DotNetAssignment.Options
{
    public class ProjectOption
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }
        public string FileName { set; get; }
        [NotMapped]
        public IFormFile MyImage { set; get; }
        public float RequiredFunds { get; set; }            
        public float CurrentFunds { get; set; }             
        public DateTime CreatedDate { get; set; }
        public DateTime Deadline { get; set; }
        public int UserId { get; set; }
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
                FileName = project.FileName;
                RequiredFunds = project.RequiredFunds;
                CurrentFunds = project.CurrentFunds;
                CreatedDate = project.CreatedDate;
                Deadline = project.Deadline;
               UserId = project.UserId;
            }
        }

        public Project GetProject()                  
        {
            return new Project
            {
               ProjectId = ProjectId,
                Title = Title,
                Description = Description,
                Category = Category,
                Country = Country,
                FileName = FileName,
                RequiredFunds = RequiredFunds,
                CurrentFunds = CurrentFunds,
                CreatedDate = CreatedDate,
                Deadline = Deadline,
                UserId=UserId

            };
        }
    }
}