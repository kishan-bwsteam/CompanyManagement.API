using CompanyManagement.Domain.Model;
using CompanyManagement.Domain.RequestDTO;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace Service.Concrete
{
    public class LeaveService : ILeaveService
    {

        EncryptHelperModel obj = new EncryptHelperModel();

        private readonly ILeaveDataRepository _ileaveDataRepository;

        public LeaveService(ILeaveDataRepository _leaveDataRepository)
        {
            this._ileaveDataRepository = _leaveDataRepository; 
        }
        public IEnumerable<LeaveStaus> GetLeaveStatus()
        {
            var res = _ileaveDataRepository.GetLeaveStaus();
            return res;
        }
        public LeaveRequestResponse GetByLeaveId(int LeaveRequestId)
        {
            DataTable filters = new DataTable("filter_type");
            filters.Columns.Add("operator", typeof(string));
            filters.Columns.Add("col", typeof(string));
            filters.Columns.Add("condition", typeof(string));
            filters.Columns.Add("val", typeof(string));

            filters.Rows.Add("AND", "LeaveRequestID", "=", LeaveRequestId.ToString());

            var result = _ileaveDataRepository.Get(filters, 1, 0);

            return result.Data.FirstOrDefault();
        }

        private DataTable CreateBaseFilter(string column, string value)
        {
            var filters = new DataTable("filter_type");
            filters.Columns.Add("operator", typeof(string));
            filters.Columns.Add("col", typeof(string));
            filters.Columns.Add("condition", typeof(string));
            filters.Columns.Add("val", typeof(string));

            filters.Rows.Add("AND", column, "=", value);

            return filters;
        }

        private void AddSearchFilters(DataTable filters, string search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                filters.Rows.Add("OR", "EmpCode", "LIKE", $"%{search}%");
                filters.Rows.Add("OR", "CompanyName", "LIKE", $"%{search}%");
                filters.Rows.Add("OR", "ReasonName", "LIKE", $"%{search}%");
                filters.Rows.Add("OR", "DepartmentName", "LIKE", $"%{search}%");
            }
        }

        public PaginatedResult<LeaveRequestResponse> GetByAdminId(int AdminId, int limit = 10, int startingRow = 0, string search = null)
        {
            DataTable filters = CreateBaseFilter("AdminId", AdminId.ToString());

            AddSearchFilters(filters, search);

            var result = _ileaveDataRepository.Get(filters, limit, startingRow);
            return result;
        }

        public PaginatedResult<LeaveRequestResponse> GetByUserId(int UserId, int limit = 10, int startingRow = 0, string search = null)
        {
            DataTable filters = CreateBaseFilter("UserId", UserId.ToString());

            AddSearchFilters(filters, search);

            var result = _ileaveDataRepository.Get(filters, limit, startingRow);
            return result;
        }

        public PaginatedResult<LeaveRequestResponse> GetByCompanyId(int companyId, int limit = 10, int startingRow = 0, string search = null)
        {
            DataTable filters = CreateBaseFilter("CompanyId", companyId.ToString());

            AddSearchFilters(filters, search);

            var result = _ileaveDataRepository.Get(filters, limit, startingRow);
            return result;
        }

        //----------------------------------------------------Save Update leave------------------------------------------------------
        public Response SaveUpdate(LeaveModel model)
        {
            try
            {
                model.LeaveStatusID = 1;
                return _ileaveDataRepository.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Response UpdateStatus(ChangeLeaveStatusModel lModel,int actionBy)
        {
            var res = _ileaveDataRepository.UpdateStatus(lModel.Status,lModel.LeaveId, actionBy);
            return res;
        } 


        public ReasonViewModel GetReason()
        {

            try
            {
                return _ileaveDataRepository.GetReason();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //-------------------------------------------Get All Leave by LeaveViewModels--------------------------------------------------


        //public LeaveViewModels GetAll(int CompanyID)
        //{
        //    try
        //    {
        //        return _ileaveDataRepository.GetAll(CompanyID);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}



        ////-------------------------------------------Get All Leave by userID--------------------------------------------


        //public LeaveViewModels GetAllUser(int userID)
        //{
        //    try
        //    {
        //        return _ileaveDataRepository.GetAllUser(userID);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


        //--------------------------------------Upload Leave approval by leaveRequestID------------------------------
        //public Response Update(int Accept, int leaveRequestID)
        //{
        //    try
        //    {
        //        return _ileaveDataRepository.Update(Accept, leaveRequestID);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        ////---------------------------------------------Get status Leave--------------------------------------------------
        //public StatusViewModel GetStatus()
        //{

        //    try
        //    {
        //        return _ileaveDataRepository.GetStatus();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        ////------------------------------------------------------------Get Reason by ReasonViewModel ------------------------------------


        ////------------------------------------------ Get Approval  by ReasonViewModel-----------------------------

        //public ReasonViewModel GetApp()
        //{

        //    try
        //    {
        //        return _ileaveDataRepository.GetApp();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        ////-------------------------------------------Get upload Attachment --------------------------------------------------

        //public Response GetAtt(LeaveModel model)
        //{

        //    try
        //    {
        //        return _ileaveDataRepository.GetAtt(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        ////---------------------------------------------Get Single Approve Leave model List by SingleApproveLeave-----------------------------------

        //public SingleApproveLeave GetSingle(int leaveRequestID)
        //{
        //    try
        //    {
        //        return _ileaveDataRepository.GetSingle(leaveRequestID);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //-------------------------------------------- Delete Leave Request by leave Request ID-------------------------------------------------------


        public Response Delete(int leaveRequestID)
        {
            try
            {
                return _ileaveDataRepository.Delete(leaveRequestID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
