using Dapper;

using Dto.Models;

using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System.Data;
using CompanyManagement.Datas.Concrete;
using Dto.Model.Common;
using Datas.Abstract;
using Microsoft.Data.SqlClient;


namespace Datas.Concrete
{
    public class ProjectRepository : IProjectRepository
    {
        public readonly IDatabaseContext dbcontext;

        #region Constructor
        public ProjectRepository(IDatabaseContext databaseContext)
        {
            dbcontext = databaseContext;
        }
        #endregion


        public async Task<ProjectListModel> GetAllProjects(int companyId)
        {
            ProjectListModel projectListModel = new ProjectListModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@companyId", companyId);
                var _result = dbcontext.Query<ProjectModel>("getProject", parameters, null, CommandType.StoredProcedure).ToList();//
                if (_result != null)
                {
                    projectListModel.Status = parameters.Get<int>("@Status");
                    projectListModel.Message = parameters.Get<string>("@Message");
                    projectListModel.Projectlst = _result;
                }
            }
            catch (Exception ex)
            {
                projectListModel.Message = ex.Message;
            }
            return projectListModel;
        }

        public async Task<ProjectWeeklyReportListModel> GetAllProjectsWeeklyReports()
        {
            ProjectWeeklyReportListModel projectWeeklyReportListModel = new ProjectWeeklyReportListModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
               
                var _result = dbcontext.Query<ProjectWeeklyReportModel>("getProjectWeeklyReport", parameters, null, CommandType.StoredProcedure).ToList();
                if (_result != null)
                {
                    projectWeeklyReportListModel.Status = parameters.Get<int>("@Status");
                    projectWeeklyReportListModel.Message = parameters.Get<string>("@Message");
                    projectWeeklyReportListModel.ProjectWeeklyReportlst = _result;
                }
            }
            catch (Exception ex)
            {
                projectWeeklyReportListModel.Message = ex.Message;
            }
            return projectWeeklyReportListModel;
        }

        public async Task<singleProjectResponseModel> GetSingleProject(int? projectId)
        {
            singleProjectResponseModel project = new singleProjectResponseModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@ProjectId", projectId);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

                var _result = dbcontext.Query<ProjectModel>("getSingleProject", parameters, null, CommandType.StoredProcedure);
                if (_result != null)
                {
                    project.singleProject = _result.FirstOrDefault();
                    project.Status = parameters.Get<int>("@Status");
                    project.Message = parameters.Get<string>("@Message");
                }
            }
            catch (Exception ex)
            {
                project.Message = ex.Message;
            }
            return project;
        }
        public async Task<singleProjectWeeklyReportResponseModel> GetSingleProjectWeeklyReport(int? projectWeeklyReportId)
        {
            singleProjectWeeklyReportResponseModel projectWeeklyReport = new singleProjectWeeklyReportResponseModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@ProjectWeeklyReportId", projectWeeklyReportId);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

                var _result = dbcontext.Query<ProjectWeeklyReportModel>("getSingleProjectWeeklyReport", parameters, null, CommandType.StoredProcedure);
                if (_result != null)
                {
                    projectWeeklyReport.singleProjectWeeklyReport = _result.FirstOrDefault();
                    projectWeeklyReport.Status = parameters.Get<int>("@Status");
                    projectWeeklyReport.Message = parameters.Get<string>("@Message");
                }
            }
            catch (Exception ex)
            {
                projectWeeklyReport.Message = ex.Message;
            }
            return projectWeeklyReport;
        }
        public async Task<Response> DeleteProjectDetails(int? projectId)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@ProjectId", projectId);

                var _result = dbcontext.Query<string>("deleteProject", parameters, null, CommandType.StoredProcedure);
                if (_result != null)
                {
                    response.Status = parameters.Get<int>("@Status");
                    response.Message = parameters.Get<string>("@Message");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response> DeleteProjectWeeklyReportDetails(int? projectWeeklyReportId)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@ProjectWeeklyReportId", projectWeeklyReportId);

                var _result = dbcontext.Query<string>("deleteProjectWeeklyReport", parameters, null, CommandType.StoredProcedure);
                if (_result != null)
                {
                    response.Status = parameters.Get<int>("@Status");
                    response.Message = parameters.Get<string>("@Message");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response> SaveupdateProject(ProjectModel model)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@ProjectId", model.ProjectId);
                parameters.Add("@ProjectAmountId", model.ProjectAmountId);
                parameters.Add("@ProjectName", model.ProjectName);
                parameters.Add("@ProfileId", model.ProfileId);
                parameters.Add("@BidderID", model.BidderId);
                parameters.Add("@ClientName", model.ClientName);
                parameters.Add("@StartingDate", model.StartingDate);
               
                parameters.Add("@DepartmentID", model.DepartmentId);
                parameters.Add("@Skills", model.Skills);
                parameters.Add("@loginUserID", model.loginUserId);

                parameters.Add("@HrsPerWeek", model.NumberOfHours);
                //parameters.Add("@Amount", model.Amount);
                parameters.Add("@HourlyRate", model.HourlyRate);

                parameters.Add("@ProjectTypeID", (int)model.ProjectTypeId);
                parameters.Add("@ProjectStatusId", (int)model.ProjectStatusId);
                parameters.Add("@Amount", model.Amount);
                parameters.Add("@CompanyId", model.CompanyId);
                parameters.Add("@SalaryTypeId", model.SalaryTypeId);


                if (model.DueDate== Convert.ToDateTime("01-01-0001 00:00:00"))
                {
                    model.DueDate = null;
                }
                parameters.Add("@DueDate", model.DueDate);//even null get passed without being a null variable
                parameters.Add("@FeedbackRecieved", model.FeedBackRecieved);
                
                parameters.Add("@RatingReceived", model.RatingReceived);
                parameters.Add("@Notes", model.Notes);
               
                var _result = dbcontext.Query<string>("saveUpdateProject", parameters, null, CommandType.StoredProcedure);
                if (_result != null)
                {
                    response.Status = parameters.Get<int>("@Status");
                    response.Message = parameters.Get<string>("@Message");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response> SaveupdateProjectWeeklyReport(ProjectWeeklyReportModel model)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@ProjectWeeklyReportId", model.ProjectWeeklyReportId);
                parameters.Add("@ProjectID", model.ProjectID);
                //parameters.Add("@Date", model.Date.Value.ToString("MM/dd/yyyy"));
                //parameters.Add("@StartTime", model.StartTime.Value.ToString("hh:mm:ss"));
                //parameters.Add("@EndTime", model.EndTime.Value.ToString("hh:mm:ss"));
                parameters.Add("@Date", model.Date);
                parameters.Add("@StartTime", model.StartTime);
                parameters.Add("@EndTime", model.EndTime);
                //use ? and make properties nllable to get above 3 work 
                parameters.Add("@TotalHours", model.TotalHours);
                parameters.Add("@loginUserID", model.loginUserID);
               
           
                var _result = dbcontext.Query<string>("saveUpdateProjectWeeklyReport", parameters, null, CommandType.StoredProcedure);
                if (_result != null)
                {
                    response.Status = parameters.Get<int>("@Status");
                    response.Message = parameters.Get<string>("@Message");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public BidderViewModel GetAllBidder(int companyId)
        {
            BidderViewModel report = new BidderViewModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@CompanyId", companyId);
              

               var _report = dbcontext.Query<BidderList>("GetAllBidder", parameters, commandType: CommandType.StoredProcedure).ToList();

                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.bidderLists = _report;
                        if (report.bidderLists.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "BidderList not found";
                        }
                    }
                }
                else
                {
                    report.bidderLists = null;
                }
            }
            catch (SqlException ex)
            {
                report.Status = (int)ErrorStatus.Exception;
                report.Message = ex.Message;
            }
            catch (DataException ex)
            {
                report.Status = (int)ErrorStatus.Exception;
                report.Message = ex.Message;
            }
            catch (Exception ex)
            {
                report.Status = (int)ErrorStatus.Exception;
                report.Message = ex.Message;
            }
            return report;

        }


    }


}

