using Dto.Model;
using Dto.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using Service.Concrete;
using System;


namespace CompanyManagement.Controllers.EmployeeController
{
    [Route("api/BankDetail/")]
    [ApiController]
    public class EmpBankController : ControllerBase
    {
        private IEmpBankService _iempBankService;
        //private IConfiguration _config;

        public EmpBankController(IEmpBankService _empBankService, IConfiguration config)
        {
            _iempBankService = _empBankService;
          //  _config = config;
        }



        // -----------------------------Save And Update Bank Details------------------------ 

        [HttpPost]
        [Authorize]
        public IActionResult SaveUpdate(UserBankDetail model)
        {

            var id = User.FindFirst("userID").Value;
            var actionBy = Int32.Parse(id);
            var result = _iempBankService.SaveUpdate(model, actionBy);
            return StatusCode(result.Status, result);
        }


        //----------------------------Get all Bank Details by BankViewModels (List)-------------------

        [HttpGet]


        public BankViewModels GetAll()
        {
            try
            {
                return _iempBankService.GetAll();
            }
         catch (Exception ex)
            {
                throw ex;
            }
        }
}

}
