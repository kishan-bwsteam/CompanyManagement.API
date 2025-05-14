using BussinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Responses
{
    public class RoleResponse:RoleModel
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
