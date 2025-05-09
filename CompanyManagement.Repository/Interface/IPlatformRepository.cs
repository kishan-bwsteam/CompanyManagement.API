using Dto.Model.Common;
using Dto.Models;

using System.Threading.Tasks;

namespace Datas.Abstract
{
    public interface IPlatformRepository
    {
        Task<PlatformListModel> GetAllPlatforms(int companyId);
        Task<singlePlatformResponseModel> GetSinglePlatform(int? platformId);
        Task<Response> DeletePlatformDetails(int? platformId);
        Task<Response> SaveupdatePlatform(PlatformModel model);
    }
}
