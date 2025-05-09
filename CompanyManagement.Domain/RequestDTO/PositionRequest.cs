using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Request
{
   public  class PositionRequest: Response
    {
    
        public string PositionName { get; set; }
        public int PositionLevel { get; set; }
        public string Abberivation { get; set; }
    }
}
