using CompanyManagement.Data.Datas.Abstract;
using CompanyManagement.Services.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyManagement.Services.Service.Concrete
{
	public class TransitTimeOperationService : ITransitTimeOperationService
	{
		private readonly ITransitTimeOperationRepository transitTimeOperationRepository;
		public TransitTimeOperationService(ITransitTimeOperationRepository transitTimeOperationRepository)
		{
			this.transitTimeOperationRepository = transitTimeOperationRepository;
		}
		public string testCheck()
		{
			string result = transitTimeOperationRepository.testCheck();
			return result;
		}
	}
}