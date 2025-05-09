using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Request
{
 public    class EmploymentRequest
    {
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int LastCTC { get; set; }
        public string WorkResponsibility { get; set; }
    }
}
