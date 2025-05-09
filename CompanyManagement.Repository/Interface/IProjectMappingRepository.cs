using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Datas.Abstract
{
   public interface IProjectMappingRepository
    {
       public Response SaveUpdateMapping(DataTable MappingProject);
        MultipleMappingView GetAllProjectList(int CompanyID);

        MultipleMappingView GetAllProjectMapping(int CompanyID, int ProjectID);
    }
}
