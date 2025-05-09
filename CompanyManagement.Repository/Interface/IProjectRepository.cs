using Dto.Model.Common;
using Dto.Models;

using System.Threading.Tasks;

namespace Datas.Abstract
{
    public interface IProjectRepository
    {
        Task<ProjectListModel> GetAllProjects(int companyId);
        Task<singleProjectResponseModel> GetSingleProject(int? projectId);
        Task<Response> DeleteProjectDetails(int? projectId);
        Task<Response> SaveupdateProject(ProjectModel model);
        Task<ProjectWeeklyReportListModel> GetAllProjectsWeeklyReports();
        Task<singleProjectWeeklyReportResponseModel> GetSingleProjectWeeklyReport(int? projectWeeklyReportId);
        Task<Response> DeleteProjectWeeklyReportDetails(int? projectWeeklyReportId);
        Task<Response> SaveupdateProjectWeeklyReport(ProjectWeeklyReportModel model);

        //Task<Response>  GetAllBidder(int companyId);
        BidderViewModel GetAllBidder(int companyId);
    }
}
