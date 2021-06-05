using PF6_Team1_DotNetAssignment.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Services
{
    public interface IPackageService
    {
        Task<PackageOption> CreatePackageAsync(PackageOption packageOption);
        Task<PackageOption> GetPackageAsync(int PackageId, int ProjectId);
        //Task<List<PackageOption>> GetPackageByProjectIdAsync(int ProjectId);
        Task<PackageOption> UpdatePackageAsync(int PackageId, PackageOption packageOption);
        Task<bool> DeletePackage(int PackageId);
    }
}
