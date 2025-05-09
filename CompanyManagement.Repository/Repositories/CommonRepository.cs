
using System.Data;

using System;
using SqlDapper;
using SqlDapper.Abstract;
using Dapper;

namespace   CompanyManagement.Datas.Concrete////CompanyManagement.Datas.Concrete.CommonRepository
{
    public class CommonRepository : DapperRepository
    {

        public CommonRepository(IDatabaseContext dbcontext) : base(dbcontext) { }

        public static DynamicParameters GetLogParameters()
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
            parameter.Add("@Message", "", DbType.String, ParameterDirection.Output);
            return parameter;

        }
    }
}