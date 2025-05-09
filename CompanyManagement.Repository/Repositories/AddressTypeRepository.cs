using CompanyManagement.Domain.Model.Common;
using CompanyManagement.Repository.Interface;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Repository.Repositories
{

    public class AddressTypeRepository : IAddressTypeRepository
    {
        public readonly IDatabaseContext _dbcontext;

        public AddressTypeRepository(IConfiguration configuration, IDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<AddressType>> GetAllAsync()
        {
            return await _dbcontext.QueryAsync<AddressType>("usp_GetAllAddressTypes", commandType: CommandType.StoredProcedure);
        }

        public async Task SaveOrUpdateAsync(AddressType addressType)
        {
            var parameters = new
            {
                addressType.AddressTypeID,
                addressType.TypeName
            };

            await _dbcontext.ExecuteAsync("usp_SaveOrUpdateAddressType", parameters, commandType: CommandType.StoredProcedure);
        }
    }


}
