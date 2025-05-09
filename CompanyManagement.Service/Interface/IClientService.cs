using Dto.Model.Common;
using Dto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IClientService
    {
        Response SaveUpdate(Client model);
        ClientMultipleView GetAll(int companyID);
        ClientSingleModelView GetById(int ClientID);
        Response ClientDelete(int ClientID);
        ProjectTypeView GetProjectType();
        ClientStatusView GetClientStatus();
    }
}
