using Dto.Model.Common;
using Dto.Models;

using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IPlatformService
    {
        Task<PlatformListModel> GetAllPlatforms(int companyId);
        Task<singlePlatformResponseModel> GetSinglePlatform(int? platformId);
        Task<Response> DeletePlatformDetails(int? platformId);
        Task<Response> SaveupdatePlatform(PlatformModel model);
    }
}
