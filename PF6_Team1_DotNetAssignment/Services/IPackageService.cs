<<<<<<< HEAD:PF6_Team1_DotNetAssignment/Services/IPackageService.cs
﻿using PF6_Team1_DotNetAssignment.Options;
=======
using PF6_Team1_DotNetAssignment.Options;
>>>>>>> 8bbe619dd7c94e131f44c7575544a84ea36a94ad:PF6_Team1_DotNetAssignment/Services/IPackageService
using System.Threading.Tasks;

namespace PF6_Team1_DotNetAssignment.Services
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
