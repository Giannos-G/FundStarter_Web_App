using PF6_Team1_DotNetAssignment.Core.Options;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Core.Services
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
