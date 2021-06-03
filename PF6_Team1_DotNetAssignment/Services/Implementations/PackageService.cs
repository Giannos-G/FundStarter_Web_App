using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PF6_Team1_DotNetAssignment.Database;
using PF6_Team1_DotNetAssignment.Models;
using PF6_Team1_DotNetAssignment.Options;
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
            
          var package =  await _context.Packages.SingleOrDefaultAsync(proj => proj.ProjectId == projectId); /////?????????

          return new PackageOption(package);

        }

        public async Task<PackageOption> GetPackageByIdAsync(int packageId)
        {
            var package = await _context.Packages.FindAsync(packageId);
            if (package == null)
            {
                return null;
            }
            return new PackageOption(package);
        }


        public async Task<PackageOption> UpdatePackageAsync(int packageId, PackageOption packageOption)
        {
            var dbPackage = await _context.Packages.FindAsync(packageId);
            if (dbPackage == null) return null;
            dbPackage.Title = packageOption.Title;
            dbPackage.Description = packageOption.Description;
            dbPackage.Price = packageOption.Price;
            dbPackage.Reward = packageOption.Reward;
            dbPackage.AmountOfBackers = packageOption.AmountOfBackers;

            await _context.SaveChangesAsync();

            return new PackageOption(dbPackage);

        }

        public async Task<bool> DeletePackage(int packageId)
        {
            var dbPackage = await _context.Packages.FindAsync(packageId);
            if (dbPackage == null) return false;
            _context.Packages.Remove(dbPackage);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
