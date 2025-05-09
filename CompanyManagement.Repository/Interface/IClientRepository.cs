using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datas.Abstract
{
    public interface IClientRepository
    {
        Response SaveUpdate(Client client);
        ClientMultipleView GetAll(int companyID);
        ClientSingleModelView GetById(int ClientID);
        Response ClientDelete(int ClientID);
        ProjectTypeView GetProjectType();
        ClientStatusView GetClientStatus();
    }
}
