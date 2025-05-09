using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
    public interface IProjectMappingService
    {
        Response SaveUpdateMapping(MultipleMappingView projectmapping);
        MultipleMappingView GetAllProjectList(int CompanyID);
        MultipleMappingView GetAllProjectMapping(int CompanyID, int ProjectID);


    }
}
