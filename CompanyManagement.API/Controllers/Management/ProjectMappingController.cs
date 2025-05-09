
using Dto.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using System;

namespace CompanyManagement.Controllers.Management
{
    [Route("api/ProjectMapping/")]
    [ApiController]
    public class ProjectMappingController : ControllerBase
    {

        private readonly IProjectMappingService _iprojectMappingService;


        public ProjectMappingController(IProjectMappingService _projectMappingService)

        {
            _iprojectMappingService = _projectMappingService;

        }




        //--------------------------------------Save Update Project Mapping-----------------------

        [HttpPost]

        public Response SaveUpdateMapping(MultipleMappingView projectmapping)
        {
            try
            {
                return _iprojectMappingService.SaveUpdateMapping(projectmapping);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        //--------------------------------------Get All Project List---------------------------


        [HttpGet("{companyId}")]


        public MultipleMappingView GetAllProjectList(int CompanyID)
        {
            try
            {
                return _iprojectMappingService.GetAllProjectList(CompanyID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        [HttpGet("ProjectMapping/{companyId}/Project/{ProjectID}")]


        public MultipleMappingView GetAllProjectMapping(int CompanyID, int ProjectID)
        {
            try
            {
                return _iprojectMappingService.GetAllProjectMapping(CompanyID, ProjectID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
}

