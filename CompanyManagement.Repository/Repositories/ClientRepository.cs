using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datas.Concrete
{
    public class ClientRepository : IClientRepository
    {
        public readonly IDatabaseContext _dbcontext;
        public ClientRepository(IDatabaseContext databaseContext)
        {
            _dbcontext = databaseContext;
        }
        public Response ClientDelete(int ClientID)
        {
            Response response=new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@Status", 1, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@ClientID", ClientID);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _report=_dbcontext.Query<string>("Client_Delete", parameters,null,CommandType.StoredProcedure);
                if(_report.Count()>0)
                {
                    response.Status = parameters.Get<int>("status");
                    response.Message = parameters.Get<string>("message");
                }
                else
                {
                    response.Status = (int)1;
                    response.Message = ("Data Deleted Successfully");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        public ClientMultipleView GetAll(int companyID)
        {
           ClientMultipleView clients = new ClientMultipleView();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@CompanyID", companyID);
                parameters.Add("@Status", 1, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _report = _dbcontext.Query<Client>("Client_GetAll", parameters, null,CommandType.StoredProcedure).ToList();
                if (_report != null)
                {
                    clients.Status = parameters.Get<int>("@Status");
                    clients.Message = parameters.Get<string>("@Message");
                    if(clients.Status == 200)
                            {
                        clients.ClientMultipleList = _report;
                        if (clients.ClientMultipleList.Count==0)
                        {
                            clients.Status = (int)ErrorStatus.Error;
                            clients.Message = "Clients Information Not Found";
                        }

                        
                    }
                   
                }
                else
                {
                    clients.ClientMultipleList = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return clients;
        }

        public ClientSingleModelView GetById(int ClientID)
        {
            ClientSingleModelView client = new ClientSingleModelView();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@Status", 1, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@ClientID", ClientID);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _report = _dbcontext.Query<Client>("Client_GetById", parameters, null, CommandType.StoredProcedure);
                if( _report != null )
                {
                    client.Status = parameters.Get<int>("Status");
                    client.Message = parameters.Get<string>("Message");
                    if (client.Status == 200)
                    {
                        client.SingleClientList=_report.FirstOrDefault();
                    }
                    if(client.SingleClientList==null)
                    {
                        client.Message = "Data Dont Exist";
                    }
                  
                }
                else
                {
                    client.SingleClientList = null;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return client;
        }

        public Response SaveUpdate(Client model)
        {
         Response response= new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("ClientID", model.ClientID);
                parameters.Add("CompanyID", model.CompanyID);
                parameters.Add("ClientName", model.ClientName);
                parameters.Add("ClientStatusID", model.ClientStatusId);
                parameters.Add("ClientAddressID", model.ClientAddressID);
                parameters.Add("AddressLine1", model.AddressLine1);
                parameters.Add("AddressLine2", model.AddressLine2);
                parameters.Add("UserAddressID", model.UserAddressID);
                parameters.Add("City", model.City);
                parameters.Add("StateID", model.StateID);
                parameters.Add("CountryID", model.CountryID);
                parameters.Add("CreatedBy", model.CreatedBy);
                parameters.Add("UpdatedBy", model.UpdatedBy);
                parameters.Add("Phone1", model.Phone1);
                parameters.Add("Phone2", model.Phone2);
                parameters.Add("EmailId", model.EmailId);
                parameters.Add("ProjectTypeId", model.ProjectTypeId);
                parameters.Add("AddressTypeID", model.AddressTypeID);
                parameters.Add("@Status", 1, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _report=_dbcontext.Query<string>("Client_SaveUpdate", parameters,null,CommandType.StoredProcedure);
                if(_report!=null )
                {

                    response.Status = parameters.Get<int>("Status");
                    response.Message = parameters.Get<string>("Message");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }


        //---------------------------------------project Type------------------------


        public ProjectTypeView GetProjectType()
        {
            ProjectTypeView GetProject = new ProjectTypeView();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@Status", 1, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _report = _dbcontext.Query<ProjectType>("ProjectTypeDropdown", parameters, null, CommandType.StoredProcedure).ToList();
                if (_report != null)
                {
                    GetProject.Status = parameters.Get<int>("@Status");
                    GetProject.Message = parameters.Get<string>("@Message");
                    if (GetProject.Status == 200)
                    {
                        GetProject.ProjectTypeList = _report;
                        if (GetProject.ProjectTypeList.Count == 0)
                        {
                            GetProject.Status = (int)ErrorStatus.Error;
                            GetProject.Message = "Project Information Not Found";
                        }


                    }

                }
                else
                {
                    GetProject.ProjectTypeList = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return GetProject;
        }




        //---------------------------------------Client Status------------------------


        public ClientStatusView GetClientStatus()
        {
            ClientStatusView GetProject = new ClientStatusView();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@Status", 1, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _report = _dbcontext.Query<ClientStatus>("ClientStatusDropdown", parameters, null, CommandType.StoredProcedure).ToList();
                if (_report != null)
                {
                    GetProject.Status = parameters.Get<int>("@Status");
                    GetProject.Message = parameters.Get<string>("@Message");
                    if (GetProject.Status == 200)
                    {
                        GetProject.ClientStatusList = _report;
                        if (GetProject.ClientStatusList.Count == 0)
                        {
                            GetProject.Status = (int)ErrorStatus.Error;
                            GetProject.Message = "Project Information Not Found";
                        }


                    }

                }
                else
                {
                    GetProject.ClientStatusList = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return GetProject;
        }



    }
}
