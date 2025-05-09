using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
namespace Dto.Model
{


    //------------------------------Department model----------------------------------------


    public class DepartmentModel 
    {
        public int DepartmentId { get; set; }

        public int? userID { get; set; }

        public string DepartmentName { get; set; }

        public string Abberivation { get; set; }

        public int? CompanyID { get; set; }
        public string? CompanyName { get; set; }
        public bool IsMarketing { get; set; }


    }


    //------------------------------------Department Model List-----------------------------------------
    public class DepartmentViewModels : Response
    {
        public List<DepartmentModel> DepartmentModelList { get; set; }

    }
    //------------------------------------Department Single Model List-----------------------------------------

    public class SingleDepartmentModel : Response
    {
        public DepartmentModel SingleDeparmentList { get; set; }

    }

}
