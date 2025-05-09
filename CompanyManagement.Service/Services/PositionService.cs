using Authentication.DataManager.Helper;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Dto.Model.Common;
using Dto.Responses;
using Service.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Concrete
{
    public class PositionService : IPositionService
    {
        EncryptHelperObj obj = new EncryptHelperObj();

        private readonly IPositionRepositiory _ipositionRepository;

        public PositionService(IPositionRepositiory _positionRepositiory)
        {
            this._ipositionRepository = _positionRepositiory;
        }




        //-----------------------------------------------------save update position---------------------------   

        public PositionResponse Saveupdate(PositionModel model)
        {
            try
            {
                return _ipositionRepository.Saveupdate(model);
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        //----------------------------------------Get All Postion by positionViewModels (List)----------------------------

        public positionViewModels Get(int companyID)
        {
            try
            {

                return _ipositionRepository.Get(companyID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //----------------------------------------------Get Single Position by RoleID----------------------------------

        public SinglePositionResponseModel GetSingle(int roleID)
        {
            try
            {
                return _ipositionRepository.GetSingle(roleID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //-----------------------------------------------Delete Position Details by RoleID----------------------------------------------- 
        public PositionResponse Delete(int roleId)
        {
            try
            {
                return _ipositionRepository.Delete(roleId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
