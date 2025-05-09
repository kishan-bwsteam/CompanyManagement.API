using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;
using System.Data;
using Microsoft.Data.SqlClient;


namespace Datas.Concrete
{
    public class SalaryRepository : ISalaryRepository
    {
        public readonly IDatabaseContext dbcontext;
        public SalaryRepository(IDatabaseContext databaseContext)
        {
            dbcontext = databaseContext;
        }


        public Response SaveUpdateSalary(SalaryModel model)
        
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@UserID", model.CreatedBy);
                parameters.Add("@SalaryComponentId", model.SalaryComponentId);
                parameters.Add("@TypeName", model.Name);
                parameters.Add("@IsDeduction", model.IncomeType);
                parameters.Add("@ComponentValue",model.ComponentValue);
                parameters.Add("@CompanyId", model.CompanyId);

                parameters.Add("@IsPercentage", model.ComponentType);
                parameters.Add("@TokenName", model.IncomeHead);
                parameters.Add("@IncomeHead", model.IncomeHead);
                parameters.Add("@UpdateBy", model.CreatedBy);


                var result = dbcontext.Query<string>("SaveUpdateSalary", parameters, null, CommandType.StoredProcedure);
                if (result != null)
                {
                    response.Status = parameters.Get<int>("@Status");
                    response.Message = parameters.Get<string>("@Message");
                }
            }
            catch (SqlException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (DataException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            return response;
        }

        public SalaryViewModel GetAllSalary()
        {
            SalaryViewModel report = new SalaryViewModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                var _report = dbcontext.Query<SalaryModel>("GetAllSalary", parameters, null, CommandType.StoredProcedure).ToList();

                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.SalaryViewModelList = _report;
                        if (report.SalaryViewModelList.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Salary not found";
                        }
                    }
                }
                else
                {
                    report.SalaryViewModelList = null;
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

        public SingleSalaryModel GetSingleSalary(int SalaryComponentId)
        {
            SingleSalaryModel report = new SingleSalaryModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@SalaryComponentId", SalaryComponentId);

                var _report = dbcontext.Query<SalaryModel>("GetSingleSalary", parameters, null, CommandType.StoredProcedure);
                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.SSModel = _report.FirstOrDefault();
                        if (report.SSModel == null)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Dept Details not found";
                        }
                    }
                    else
                    {
                        report.SSModel = null;
                    }
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

        public Response DeleteSalary(int salaryComponentId)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@SalaryComponentId", salaryComponentId);

                var result = dbcontext.Query<string>("DeleteSalary", parameters, null, CommandType.StoredProcedure);
                if (result != null)
                {
                    response.Status = parameters.Get<int>("@Status");
                    response.Message = parameters.Get<string>("@Message");
                }
                

            }
            catch (SqlException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (DataException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            return response; 
        }

        public GetSalaryComponentTypeView GetSalaryComponentType(int companyid)
        {
            GetSalaryComponentTypeView report = new GetSalaryComponentTypeView();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
               
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

              

                var _report = dbcontext.Query<GetSalaryComponentType>("SalaryComponentTypeN", parameters, null, CommandType.StoredProcedure).ToList();

                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.SalaryComponentTypes = _report;
                        if (report.SalaryComponentTypes.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Salary not found";
                        }
                    }
                }
                else
                {
                    report.SalaryComponentTypes= null;
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
        public Response UpdateSalVal(SalaryNameModel nameModel,string structureName,int StructureId)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@DisplayName", nameModel.DisplayName); 
                parameters.Add("@CompSalCompoDetID", nameModel.CompSalCompoDetID);
                parameters.Add("@CompanySalaryComponentID", StructureId);
                parameters.Add("@ComponentValue", nameModel.ComponentValue);
                parameters.Add("@SalaryComponentID", nameModel.SalaryComponentID);
                parameters.Add("@ComponentTypeId", nameModel.ComponentTypeId);
                parameters.Add("@CompanyId", nameModel.CompanyId);
                parameters.Add("@StructureName", structureName);
                var result = dbcontext.Query<string>("UpdateSalVal", parameters, null, CommandType.StoredProcedure);
                if (result != null)
                {
                    response.Status = parameters.Get<int>("@Status");
                    response.Message = parameters.Get<string>("@Message");
                }
            }
            catch (SqlException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (DataException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            return response;
        }


        public Response UpdateFeildName(UpdateFeildName nameModel)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@SalaryComponentID", nameModel.SalaryComponentID);
                parameters.Add("@SalaryComponentName", nameModel.Name);
                parameters.Add("UpdatedBy", nameModel.UpdatedBy);
                parameters.Add("@CompanyId", nameModel.CompanyId);
                var result = dbcontext.Query<string>("UpdateFeildName", parameters, null, CommandType.StoredProcedure);
                if (result != null)
                {
                    response.Status = parameters.Get<int>("@Status");
                    response.Message = parameters.Get<string>("@Message");
                }
            }
            catch (SqlException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (DataException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            return response;
        }





        public SalaryNameViewModel GetSalaryName(string data)
        {
            SalaryNameViewModel report = new SalaryNameViewModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                var split = data.Split('-');
                parameters.Add("@CompanyID", Int32.Parse(split[0]));
                parameters.Add("@CompanySalaryComponentID", Int32.Parse(split[1]));
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _report = dbcontext.Query<SalaryNameModel>("GetSalaryName", parameters, null, CommandType.StoredProcedure).ToList();

                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.salaryname = _report;
                        if (report.salaryname.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Salary not found";
                        }
                    }
                }
                else
                {
                    report.salaryname = null;
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

        //------------------------------------------------------------------------------------SaveUpdateSalaryStructure
        public Response SaveUpdateSalaryStructure(CompanySalaryStructureModel model)

        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@CompanySalrayComponentId", model.CompanySalrayComponentId);
                parameters.Add("@SalaryStructureName", model.SalaryStructureName);
                parameters.Add("@CompanyId", model.CompanyId);
                parameters.Add("@CreatedBy", model.CreatedBy);


                var result = dbcontext.Query<string>("saveUpdateSalaryStructure", parameters, null, CommandType.StoredProcedure);
                if (result != null)
                {
                    response.Status = parameters.Get<int>("@Status");
                    response.Message = parameters.Get<string>("@Message");
                }
            }
            catch (SqlException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (DataException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            return response;
        }
        //------------------------------------------------------------------------------------GetSalaryStructure
        public CompanySalaryStructreView GetAllSalaryStructure(int companyId)
        {
            CompanySalaryStructreView report = new CompanySalaryStructreView();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                parameters.Add("@CompanyId", companyId);

                var _report = dbcontext.Query<CompanySalaryStructureModel>("GetAllSalaryStructure", parameters, null, CommandType.StoredProcedure).ToList();

                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.CompanyStructureList = _report;
                        if (report.CompanyStructureList.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Salary not found";
                        }
                    }
                }
                else
                {
                    report.CompanyStructureList = null;
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
        //------------------------------------------------------------------------------------GetSalaryStructureSingle
        public CompanySalaryStructureModel GetSingleSalaryStructure(int structureId)
        {
            CompanySalaryStructureModel report = new CompanySalaryStructureModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                parameters.Add("@structureId", structureId);

                var _report = dbcontext.Query<CompanySalaryStructureModel>("GetSingleSalaryStructure", parameters, null, CommandType.StoredProcedure);

                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report = _report.FirstOrDefault();
                        if (report == null)
                        {
                            //report.Status = (int)ErrorStatus.Error;
                            report.Message = "Salary not found";
                        }
                    }
                }
                else
                {
                    report = null;
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


        //------------------------------------------------------------------------------------DeleteSalaryStructure
        public Response DeleteSalaryStructure(int SalaryComponentId)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@CompanySalrayComponentId", SalaryComponentId);

                var result = dbcontext.Query<string>("DeleteSalaryStructure", parameters, null, CommandType.StoredProcedure);
                if (result != null)
                {
                    response.Status = parameters.Get<int>("@Status");
                    response.Message = parameters.Get<string>("@Message");
                }


            }
            catch (SqlException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (DataException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            return response;
        }

    }
}

