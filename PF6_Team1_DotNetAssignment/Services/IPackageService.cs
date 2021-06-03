using PF6_Team1_DotNetAssignment.Options;
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Sevices
{
    public interface IPackageService
    {
        Task<PackageOption> CreatePackageAsync(PackageOption packageOption);
        Task<PackageOption> GetPackageAsync(int PackageId, int ProjectId);
        Task<PackageOption> GetPackageByIdAsync(int PackageId);
        Task<PackageOption> UpdatePackageAsync(int PackageId, PackageOption packageOption);
        Task<bool> DeletePackage(int PackageId);
    }
}
