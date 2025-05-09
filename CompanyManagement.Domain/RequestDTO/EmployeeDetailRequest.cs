using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Request
{
    public class EmployeeDetailRequest
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }



        public int Status { get; set; }
        public string Message { get; set; }
    }
}
