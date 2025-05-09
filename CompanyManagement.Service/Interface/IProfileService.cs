using Dto.Model.Common;
using Dto.Models;

using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IProfileService
    {
        Task<ProfileListModel> GetAllProfiles(int companyId);
        Task<singleProfileResponseModel> GetSingleProfile(int? profileId);
        Task<Response> DeleteProfileDetails(int? profileId);
        Task<Response> SaveupdateProfile(ProfileModel model);
    }
}
