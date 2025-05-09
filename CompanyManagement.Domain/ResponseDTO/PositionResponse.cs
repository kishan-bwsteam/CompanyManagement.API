using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Responses
{
  public   class PositionResponse : Response
    {
        public int RoleID { get; set; }
        public string PositionName { get; set; }
        public int PositionLevel { get; set; }
        public string Abberivation { get; set; }
        public int userID { get; set; }
        public int companyID { get; set; }
    }
}
