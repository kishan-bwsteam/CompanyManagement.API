using Dto.Model.Common;
using Dto.Models;

using System.Threading.Tasks;

namespace Datas.Abstract
{
    public interface IProfileRepository
    {
        Task<ProfileListModel> GetAllProfiles(int companyId);
        Task<singleProfileResponseModel> GetSingleProfile(int? profileId);
        Task<Response> DeleteProfileDetails(int? profileId);
        Task<Response> SaveupdateProfile(ProfileModel model);
    }
}
