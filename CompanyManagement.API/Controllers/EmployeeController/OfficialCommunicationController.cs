
using Dto.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;


namespace CompanyManagement.Controllers.EmployeeController
{
    [Route("api/OfficialCommunication/")]
    [ApiController]
    public class OfficialCommunicationController : ControllerBase
    {
        private readonly IOfficialCommunicationService _iofficialCommunicationService;
        private readonly IConfiguration _config;

        public OfficialCommunicationController(IOfficialCommunicationService _officialCommunicationService, IConfiguration config )
         {
            _iofficialCommunicationService = _officialCommunicationService;
            this._config = config;
         }




        //--------------------------------------------Save Upadte Offical information----------------------


        // [HttpPut]
        //// [Route("SaveUpdateOffical")]
        // public OfficalCommResponse SaveUpdate(OfficalCommModel model)
        // {
        //     try
        //     {
        //         return _iofficialCommunicationService.SaveUpdate(model);
        //     }
        //     catch (Exception ex)
        //     {
        //         throw ex;
        //     }
        // }



        //------------------------------------------- Get All offical Communication by OfficalViewModel--------------

        //[HttpGet("Get")]
        ////[Route("GetallDetails/")]
        //public OfficalViewModel Get()
        //{
        //    try
        //    {
        //        return _iofficialCommunicationService.Get();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //------------------------------------------- Get SaveUpdate Other-----------------------------------------

        [HttpPost]
      
        public OfficalCommResponse SaveUpdate(OfficialOtherModel model)
        {
            try
            {
                return _iofficialCommunicationService.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //----------------------------------------Get AllOthers Details by   OfficalOtherModelList-----------------------------------------

        [HttpGet]
    
        public OfficalOtherModelList Get()
        {
            try
            {
                return _iofficialCommunicationService.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //-----------------------------------------------------Delete Offical Details by OfficalID--------------------------------

        [HttpDelete("{OfficalID}")]
       
        public OfficalCommResponse Delete(int OfficalID)
        {
            OfficalCommResponse resp=new OfficalCommResponse();
            try
            {
                resp= _iofficialCommunicationService.Delete(OfficalID);

                return resp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
