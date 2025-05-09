using System;
using System.Collections.Generic;
using System.Text;
using Dto.Model.Common;

namespace Dto.Model
{
    //--------------------------------------------------- Employment Model----------------------------------------

   public class EmploymentModel 
    {


            public int EmploymentID { get; set; }
            public int UserID { get; set; }
            public string CompanyName { get; set; }
            public string Position { get; set; }
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }
            public int CTC { get; set; }
            public string Responsibilities { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }


    }

    //--------------------------------------------------- Employment Model List----------------------------------------
    public class AllEmploymentList :Response
    {
        public List<EmploymentModel> EmploymentListModel { get; set; }
    }


    //--------------------------------------------------- Employment Single Model List----------------------------------------

    public class SingleEmpModel : Response
    {
        public EmploymentModel SingleModelList { get; set; }
    }
}
 