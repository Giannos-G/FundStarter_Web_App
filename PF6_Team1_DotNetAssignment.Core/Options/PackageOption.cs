using PF6_Team1_DotNetAssignment.Core.Models;

namespace PF6_Team1_DotNetAssignment.Core.Options
{
    public class PackageOption
    {
        public int PackageId { get; set; }
        public float Price { get; set; }                // decimal
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reward { get; set; }
        public int AmountOfBackers { get; set; }
        public int ProjectId { get; set; }

        public PackageOption() { }
        public PackageOption(Package package)
        {
            if (package != null)
            {
                PackageId = package.PackageId;
                Title = package.Title;
                Description = package.Description;
                Price = package.Price;
                Reward = package.Reward;
                AmountOfBackers = package.AmountOfBackers;

            }
        }

        public Package GetPackage()
        {
            return new Package
            {
                PackageId = PackageId,
                Title = Title,
                Description = Description,
                Price = Price,
                Reward = Reward,
                AmountOfBackers = AmountOfBackers,
                ProjectId = ProjectId
            };
        }


    }
}


