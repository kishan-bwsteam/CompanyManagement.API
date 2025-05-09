using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;
using System.Collections.Generic;

namespace CompanyManagement.Controllers
{
    [Route("api/Client")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientService _iclientService;
        private readonly IConfiguration _iconfiguration;
        public ClientController(IClientService clientService, IConfiguration configuration)
        {
            _iclientService = clientService;
            _iconfiguration = configuration;
        }
        [HttpPost]
        public Response SaveUpdate(Client model)
        {
            try
            {
                return _iclientService.SaveUpdate(model);
            }
            catch (System.Exception)
            {

                return null;
            }
        }
        [HttpGet ("{companyID}")]
        public ClientMultipleView GetAll(int companyID)
        {
            try
            {
                return _iclientService.GetAll(companyID);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpGet("Single/{ClientID}")]
       
        public ClientSingleModelView GetById(int ClientID)
        {
            try 
            {
                return _iclientService.GetById(ClientID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        [HttpDelete("{ClientID}")]
        public Response Delete(int ClientID)
        {

            try
            {
                return _iclientService.ClientDelete(ClientID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        [HttpGet ("Project")]
        public ProjectTypeView GetProjectType()
        {
            try
            {
                return _iclientService.GetProjectType();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("Client")]
        public ClientStatusView GetClientStatus()
        {
            try
            {
                return _iclientService.GetClientStatus();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
