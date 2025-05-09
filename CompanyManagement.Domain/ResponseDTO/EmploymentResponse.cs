using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Responses
{
  public   class EmploymentResponse
    {
        public int EmploymentID { get; set; }
        public int UserID { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int LastCTC { get; set; }
        public string WorkResponsibility { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }

    }
}
