using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Model
{
    public class Client
    {
        public long ClientID { get; set; }
        public long CompanyID { get; set; }
        public string ClientName { get; set; }
        public string TypeName { get; set; }
        public string StatusName { get; set; }
        public long ClientStatusId { get; set; }
        public int ClientAddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int UserAddressID { get; set; }
        public string City { get; set; }
        public long StateID { get; set; }
        public long CountryID { get; set; }
        public string EmailId { get; set; }
        public int ProjectTypeId { get; set; }
        public int AddressTypeID { get; set; }
        public long Phone1 { get; set; }
        public long Phone2 { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
    }
    public class ClientSingleModelView:Response
    {
        public Client SingleClientList { get; set; }
    }

    public class ClientMultipleView :Response
    {
        public List<Client> ClientMultipleList { get; set; }
    }

    public class ProjectType:Response
    {
        public int ProjectTypeId { get; set; }
        public string TypeName { get; set; }
    }

    public class ProjectTypeView :Response
    {
        public List<ProjectType>ProjectTypeList { get; set; }
    }


    public class ClientStatus : Response
    {
        public int ClientStatusId { get; set; }
        public string StatusName { get; set; }
    }

    public class ClientStatusView : Response
    {
        public List<ClientStatus> ClientStatusList { get; set; }
    }

}
