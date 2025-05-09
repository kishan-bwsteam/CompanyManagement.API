using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Model
{
    //-----------------------------------------Position Model--------------------------------------
  public  class PositionModel
    {   
        public int PositionID { get; set; }
        public string PositionName { get; set; }
        public int PositionLevel { get; set; }
        public string Abberivation { get; set; }
        public int UserID { get; set; }
        public int companyID { get; set; }
        public int DepartmentID { get; set; }
    }

    //-----------------------------------------Position Model List--------------------------------------
    public class positionViewModels : Response
    {
        public List<PositionModel> positionViewModel { get; set; }
    }

    //-----------------------------------------Position Single Model List--------------------------------------
    public class SinglePositionResponseModel : Response
    {
        public PositionModel PModel { get; set; }
    }
}
