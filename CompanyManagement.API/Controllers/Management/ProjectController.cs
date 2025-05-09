using Dto.Model.Common;
using Dto.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service.Abstract;
using Service.Concrete;
using System;
using System.Threading.Tasks;
namespace API.Controllers
{
    [Route("api/ProjectController")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
       
        private readonly IProjectService projectService;
        //private readonly IConfiguration _config;

        #region Constructor
        //public ProjectController(IProjectService _projectService, IConfiguration configuration)
        public ProjectController(IProjectService _projectService)

        {
            projectService = _projectService;
           // _config = configuration;
        }
        #endregion

        #region Action Methods
        [HttpGet("company/{companyId}")]
        public async Task<ProjectListModel> GetAllProjects(int companyId)
        {
            ProjectListModel projectListModel = new ProjectListModel();
            try
            {
                projectListModel =await projectService.GetAllProjects(companyId);
            }
            catch (Exception ex)
            {
                projectListModel.Status = 500;
                projectListModel.Message = ex.Message.ToString();
            }
            return projectListModel;
        }
        //[HttpGet]
        //public async Task<ProjectWeeklyReportListModel> GetAllProjectsWeeklyReports()
        // {
        //    ProjectWeeklyReportListModel projectWeeklyReportListModel = new ProjectWeeklyReportListModel();
        //    try
        //    {
        //        projectWeeklyReportListModel =await projectService.GetAllProjectsWeeklyReports();
        //    }
        //    catch (Exception ex)
        //    {
        //        projectWeeklyReportListModel.Status = 500;
        //        projectWeeklyReportListModel.Message = ex.Message.ToString();
        //    }
        //    return projectWeeklyReportListModel;
        //}
        
        [HttpGet("single/{projectId}")]
        public async Task<singleProjectResponseModel> GetSingleProject(int? projectId)
        {
            singleProjectResponseModel projectResponseModel = new singleProjectResponseModel();
            try
            {
                projectResponseModel= await projectService.GetSingleProject(projectId);
            }
            catch (Exception ex)
            {
                projectResponseModel.Status = 500;
                projectResponseModel.Message = ex.Message.ToString();
            }
            return projectResponseModel;
        }

        [HttpGet]
        public async Task<singleProjectWeeklyReportResponseModel> GetSingleProjectWeeklyReport(int? projectWeeklyReportId)
        {
            singleProjectWeeklyReportResponseModel projectWeeklyReportResponseModel = new singleProjectWeeklyReportResponseModel();
            try
            {
                projectWeeklyReportResponseModel =await projectService.GetSingleProjectWeeklyReport(projectWeeklyReportId);
            }
            catch (Exception ex)
            {
                projectWeeklyReportResponseModel.Status = 500;
                projectWeeklyReportResponseModel.Message = ex.Message.ToString();
            }
            return projectWeeklyReportResponseModel;
        }

        [HttpDelete("delete/{projectId}")]
        public async Task<Response> DeleteProjectDetails(int? projectId)
        {
            Response response = new Response();
            try
            {
                response= await projectService.DeleteProjectDetails(projectId);;
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = ex.Message.ToString();
            }
            return response;
        }

        //[HttpGet]
        //public async Task<Response> DeleteProjectWeeklyReportDetails(int? projectWeeklyReportId)
        //{
        //    Response response = new Response();
        //    try
        //    {
        //      response=await projectService.DeleteProjectWeeklyReportDetails(projectWeeklyReportId);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = 500;
        //        response.Message = ex.Message.ToString();
        //    }
        //    return response;
        //}

        [HttpPost("SaveupdateProject")]
        public async Task<Response> SaveupdateProject(ProjectModel model)
        {
            Response response = new Response();
            try
            {
                response= await projectService.SaveupdateProject(model);
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = ex.Message.ToString();
            }
            return response;
        }


        [HttpPost]
        public async Task<Response> SaveupdateProjectWeeklyReport(ProjectWeeklyReportModel model)
        {
            Response response = new Response();
            try
            {
                response= await projectService.SaveupdateProjectWeeklyReport(model);             
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = ex.Message.ToString();
            }
            return response;
        }


        //[HttpGet("GetBidder")]

        //public async BidderViewModel GetAllBidder(int companyId)
        //{
        //    BidderViewModel response = new BidderViewModel();
        //    try
        //    {
        //        response = await ProjectService.GetAllBidder(companyId);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = 500;
        //        response.Message = ex.Message.ToString();
        //    }
        //    return response;
        //}



        #endregion
        [HttpGet("GetBidder/{companyId}")]

        public BidderViewModel GetAllBidder(int companyID)
        {
            try
            {
                return projectService.GetAllBidder(companyID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
