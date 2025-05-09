using CompanyManagement.Datas.Concrete;
using Dapper;
using Dto.Model.Common;
using Dto.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDapper.Abstract;
using CompanyManagement.Repository.Interface;

namespace CompanyManagement.Repository.Repositories
{
    public class AdminRepository:IAdminRepository
    {


        public readonly IDatabaseContext _idb_context;

        public AdminRepository(IDatabaseContext _dbcontext)
        {
            _idb_context = _dbcontext;
        }

        public Response SaveUpdate(MultiformModel model, DataTable dt)
        {
            Response response = new Response();
            try
            {
                //DataTable dt = new DataTable();
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                parameters.Add("@FirstName", model.ManageFranchise.FirstName);
                parameters.Add("@MiddleName", model.ManageFranchise.MiddleName);
                parameters.Add("@LastName", model.ManageFranchise.LastName);
                parameters.Add("@UserName ", model.Credential.UserName);
                parameters.Add("@IsActive ", 1);
                parameters.Add("@UserID", model.ManageFranchise.userid);
                parameters.Add("@IsDeleted ", 0);
                parameters.Add("@CreatedBy", 2);
                parameters.Add("@UserTypeID", 2);
                parameters.Add("@UpdatedBy", 1);
                parameters.Add("@UserEmailId ", 1);
                parameters.Add("@EmailID ", model.ManageFranchise.EmailID);
                parameters.Add("@IsPrimary", 1);
                parameters.Add("@PassKeyId", 1);
                parameters.Add("@PassKey ", model.PassKey);
                parameters.Add("@SaltKey", model.SaltKey);
                parameters.Add("@SaltKeyIV", model.SaltKeyIV);
                parameters.Add("@AddressTypeId ", 1);
                parameters.Add("@City ", model.ManageFranchise.City);
                parameters.Add("@StateId ", model.ManageFranchise.State);
                parameters.Add("@ZipCode ", model.ManageFranchise.ZipCode);
                parameters.Add("@CountryID ", model.ManageFranchise.Country);
                parameters.Add("@AddressLine1", model.ManageFranchise.AddressLine1);
                parameters.Add("@AddressLine2", model.ManageFranchise.AddressLine2);



                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

                parameters.Add("@companydetails", dt, DbType.Object);


                var result = _idb_context.Query<string>("SaveUpdateUser", parameters, null, CommandType.StoredProcedure);
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
