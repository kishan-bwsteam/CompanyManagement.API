using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManagement.Controllers.ResetPassword
{
    [Route("api/ResetPassword/")]
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {
		private readonly IResetPasswordService _iresetPasswordService;
		private readonly IConfiguration _config;


		public ResetPasswordController(IResetPasswordService _resetPasswordService, IConfiguration config)
		{
			this._iresetPasswordService = _resetPasswordService;
			_config = config;
		}

        //------------------------------------Reset Password-----------------------------------------------

        [HttpPut]
       
        public Response Reset(ResetPasswordModel model)
        {
            try
            {
                return _iresetPasswordService.Reset(model);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //--------------------------------- Save Update Password ------------------------------

        [HttpPost]
    
        public Response SaveUpdate([FromBody] ChangePasswordModel changemodel)
        {
            try
            {
                return _iresetPasswordService.SaveUpdate(changemodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
