using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PF6_Team1_DotNetAssignment.Database;
using PF6_Team1_DotNetAssignment.Models;
using PF6_Team1_DotNetAssignment.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Services.Implementations
{
    class PackageService : IPackageService
    {

        private readonly Team1DbContext _context;
        private readonly ILogger<PackageService> _logger;

        public PackageService(Team1DbContext context, ILogger<PackageService> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<PackageOption> CreatePackageAsync(PackageOption packageOption)
        {

            if (packageOption == null)
            {
                return null;
            }

            Package package = packageOption.GetPackage();
            await _context.Packages.AddAsync(package);
            await _context.SaveChangesAsync();

            return new PackageOption(package);
        }

        public async Task<PackageOption> GetPackageAsync(int packageId, int projectId)
        {

            var package = await _context.Packages.SingleOrDefaultAsync(proj => proj.ProjectId == projectId); /////?????????

            return new PackageOption(package);

        }

        //public async Task<List<PackageOption>> GetPackageByProjectIdAsync(int projectId)
        //{
        //    var project = await _context.Projects.FindAsync(projectId);
        //    if (project == null)
        //    {
        //        return null;
        //    }

        //    var new_package_list = new List<PackageOption>();
        //    foreach (var Package in project.MyPackages)
        //    {
        //        new_package_list.Add(new PackageOption
        //        {
        //            PackageId = Package.PackageId,
        //            Title = Package.Title,
        //            Price = Package.Price,
        //            Description = Package.Description,
        //            Reward = Package.Reward,
        //            AmountOfBackers = Package.AmountOfBackers,
        //            ProjectId = Package.ProjectId
        //        });
        //    }
        //    return new_package_list;
        //}

        public async Task<PackageOption> UpdatePackageAsync(int packageId, PackageOption packageOption)
        {
            var dbPackage = await _context.Packages.FindAsync(packageId);
            if (dbPackage == null) return null;
            dbPackage.Title = packageOption.Title;
            dbPackage.Description = packageOption.Description;
            dbPackage.Price = packageOption.Price;
            dbPackage.Reward = packageOption.Reward;
            //dbPackage.AmountOfBackers = packageOption.AmountOfBackers;

            await _context.SaveChangesAsync();

            return new PackageOption(dbPackage);

        }

        public async Task<bool> DeletePackage(int packageId)
        {
            var dbPackage = await _context.Packages.FindAsync(packageId);
            if (dbPackage == null) return false;
            _context.Packages.Remove(dbPackage);
            return true;
        }

    }
}
