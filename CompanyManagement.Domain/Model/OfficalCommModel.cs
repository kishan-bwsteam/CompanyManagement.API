using Dto.Model.Common;
using System;
using System.Collections.Generic;


namespace Dto.Model
{

    //--------------------------------------------offical Communication model----------------------------------------------
    public class OfficalCommModel
    {


        public int OfficialId { get; set; }
        public int UserID { get; set; }

        public int EmpCode { get; set; }

        public DateTime DOH { get; set; }
        public string EmailId { get; set; }
        public long PhoneNo { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int @CreatedBy { get; set; }
        public int @UpdatedBy { get; set; }

    }

    //--------------------------------------------offical Communication model (List)----------------------------------------------
    public class OfficalViewModel : Response
    {
        public List<OfficalCommModel> OfficalCommList { get; set; }
    } 
}

//--------------------------------------------offical other model ----------------------------------------------
public class OfficialOtherModel:Response
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int OfficialID { get; set; }
        public int @CreatedBy { get; set; }
        public int @UpdatedBy { get; set; }
    }


//--------------------------------------------offical other model (List)----------------------------------------------
public class OfficalOtherModelList : Response 
    {
        public List<OfficialOtherModel> OfficalOthersList { get; set; }
    }

   

