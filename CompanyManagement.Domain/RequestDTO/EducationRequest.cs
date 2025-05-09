using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Request
{
   public    class EducationRequest: Response
    { 
          public string degree { get; set; }
    public string InstitutionName { get; set; }
    public int passingYear { get; set; }
    public float marksPercentage { get; set; }
  

    
    }
}
