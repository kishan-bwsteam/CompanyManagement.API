using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.RequestDTO
{
    public class ChangeLeaveStatusModel
    {
        public int LeaveId { get; set; }
        public int Status { get; set; }
    }

}
