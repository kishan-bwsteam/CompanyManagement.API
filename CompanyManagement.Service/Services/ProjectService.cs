
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model.Common;
using Dto.Models;
using Service.Abstract;
using SqlDapper.Concrete;
using System;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class ProjectService:IProjectService
    {
        private readonly IProjectRepository _projectRepository;


        #region Constructor
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        #endregion


        public async Task<ProjectListModel> GetAllProjects(int companyId)
        {
            ProjectListModel projectListModel = new ProjectListModel();
            try
            {
                projectListModel =await _projectRepository.GetAllProjects(companyId);

                return projectListModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ProjectWeeklyReportListModel> GetAllProjectsWeeklyReports()
        {
            ProjectWeeklyReportListModel projectWeeklyReportListModel = new ProjectWeeklyReportListModel();
            try
            {
                projectWeeklyReportListModel = await _projectRepository.GetAllProjectsWeeklyReports();

                return projectWeeklyReportListModel;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<singleProjectResponseModel> GetSingleProject(int? projectId)
        {
            singleProjectResponseModel singleProjectResponseModel = new singleProjectResponseModel();
            try
            {
                singleProjectResponseModel=await _projectRepository.GetSingleProject(projectId);
                return singleProjectResponseModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<singleProjectWeeklyReportResponseModel> GetSingleProjectWeeklyReport(int? projectWeeklyReportId)
        {
            singleProjectWeeklyReportResponseModel singleProjectWeeklyReportResponseModel = new singleProjectWeeklyReportResponseModel();
            try
            {
                singleProjectWeeklyReportResponseModel=await _projectRepository.GetSingleProjectWeeklyReport(projectWeeklyReportId);
                return singleProjectWeeklyReportResponseModel;
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }
        public async Task<Response> DeleteProjectDetails(int? projectId)
        {
            Response response = new Response();
            try
            {
                response=await _projectRepository.DeleteProjectDetails(projectId);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Response> DeleteProjectWeeklyReportDetails(int? projectWeeklyReportId)
        {
            Response response = new Response();
            try
            {
                response=await _projectRepository.DeleteProjectWeeklyReportDetails(projectWeeklyReportId);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
          
        }

        public async Task<Response> SaveupdateProject(ProjectModel model)
        {
            Response response = new Response();
            try
            {
                response=await _projectRepository.SaveupdateProject(model);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Response> SaveupdateProjectWeeklyReport(ProjectWeeklyReportModel model)
         {
            Response response = new Response();

            try
            {
                response=await _projectRepository.SaveupdateProjectWeeklyReport(model);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public BidderViewModel GetAllBidder(int companyId)
        {
            try
            {
                return _projectRepository.GetAllBidder(companyId);
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
