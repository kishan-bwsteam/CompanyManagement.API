using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Responses
{
 public  class DepartmentResponse
    {
		public int DepartmentId { get; set; }

		public int userID { get; set; }

		public string DepartmentName { get; set; }

		public string Abberivation { get; set; }

		public int CompanyID { get; set; }
		public string CompanyName { get; set; }

		public bool IsDeleted { get; set; }

		public DateTime CreatedOn { get; set; }
		public DateTime UpdatedOn { get; set; }

		public int UpdatedBy { get; set; }

		public int CreatedBy { get; set; }

	}
}
