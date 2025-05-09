using CompanyManagement.Data.Datas.Abstract;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CompanyManagement.Data.Datas.Concrete
{
	public class TransitTimeOperationRepository: ITransitTimeOperationRepository
	{
		private readonly IDatabaseContext dbcontext;
		public TransitTimeOperationRepository(IDatabaseContext _dbcontext)
		{
			this.dbcontext = _dbcontext;
		}

		public string testCheck() {
			var _TemplateList = this.dbcontext.Query("GetAllPurchaseOrder", null, null, CommandType.StoredProcedure);			
			string result = "hello";
			return result;
		}

	}
}
