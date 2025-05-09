using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Concrete
{
    public class ShiftRulesService : IShiftRulesService
    {
        private readonly IShiftRulesRepository _ishiftRulesRepository;
        public ShiftRulesService(IShiftRulesRepository _shiftRulesRepository)
        {
            _ishiftRulesRepository = _shiftRulesRepository;
        }






        //---------------------------- Save And Update Shift---------------------------- 

        

        public Response SaveUpdate(ShiftRulesModel shiftRulesModel)
        {
            try
            {
                return _ishiftRulesRepository.SaveUpdate(shiftRulesModel);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //---------------------------- Get All Shift Rule shiftRuleId---------------------------- 


        public ShiftRulesModel GetSingle(int shiftRuleId)
        {
            try
            {
                return _ishiftRulesRepository.GetSingle(shiftRuleId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //-------------------------- Delete Shift By shiftRuleId-----------------

     
        public Response Delete(int shiftRuleId)
        {
            try
            {
                return _ishiftRulesRepository.Delete(shiftRuleId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //--------------------------- Get All Shift By AllShiftRulesModel-----------------

    
        public AllShiftRulesModel GetAll()
        {
            try
            {
                return _ishiftRulesRepository.GetAll();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
