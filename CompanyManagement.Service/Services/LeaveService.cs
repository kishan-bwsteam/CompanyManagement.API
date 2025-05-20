using CompanyManagement.Domain.Model;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using SqlDapper.Concrete;
using System;


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


        //-------------------------------------------Get All Leave by LeaveViewModels--------------------------------------------------


        public LeaveViewModels GetAll(int CompanyID)
        {
            try
            {
                return _ileaveDataRepository.GetAll(CompanyID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        //-------------------------------------------Get All Leave by userID--------------------------------------------


        public LeaveViewModels GetAllUser(int userID)
        {
            try
            {
                return _ileaveDataRepository.GetAllUser(userID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //--------------------------------------Upload Leave approval by leaveRequestID------------------------------
        public Response Update(int Accept, int leaveRequestID)
        {
            try
            {
                return _ileaveDataRepository.Update(Accept, leaveRequestID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //---------------------------------------------Get status Leave--------------------------------------------------
        public StatusViewModel GetStatus()
        {

            try
            {
                return _ileaveDataRepository.GetStatus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //------------------------------------------------------------Get Reason by ReasonViewModel ------------------------------------
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


        //------------------------------------------ Get Approval  by ReasonViewModel-----------------------------

        public ReasonViewModel GetApp()
        {

            try
            {
                return _ileaveDataRepository.GetApp();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //-------------------------------------------Get upload Attachment --------------------------------------------------

        public Response GetAtt(LeaveModel model)
        {

            try
            {
                return _ileaveDataRepository.GetAtt(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //---------------------------------------------Get Single Approve Leave model List by SingleApproveLeave-----------------------------------

        public SingleApproveLeave GetSingle(int leaveRequestID)
        {
            try
            {
                return _ileaveDataRepository.GetSingle(leaveRequestID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
