using SqlDapper.Abstract;
using System;

namespace SqlDapper
{
    public abstract class DapperRepository
    {
		protected IDatabaseContext databaseContext { get; private set; }

		protected DapperRepository(IDatabaseContext databaseContext)
		{
			if (databaseContext == null)
			{
				throw new ArgumentNullException("databaseContext");
			}
			this.databaseContext = databaseContext;
		}

		protected DapperRepository()
		{

		}
	}
}
