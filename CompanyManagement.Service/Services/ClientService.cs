using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public Response ClientDelete(int ClientID)
        {
            try
            {
                return _clientRepository.ClientDelete(ClientID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClientMultipleView GetAll(int companyID)
        {
            try
            {
                return _clientRepository.GetAll(companyID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClientSingleModelView GetById(int ClientID)
        {
            try
            {
                return _clientRepository.GetById(ClientID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Response SaveUpdate(Client client)
        {
            try
            {
                return _clientRepository.SaveUpdate(client);
            }
            catch (Exception)
            {

                throw;
            }
        }



        ///--------------------------Project Type---------------------------------
        ///

        public ProjectTypeView GetProjectType()
        {
            try
            {
                return _clientRepository.GetProjectType();
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }



        public ClientStatusView GetClientStatus()
        {
            try
            {
                return _clientRepository.GetClientStatus();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
