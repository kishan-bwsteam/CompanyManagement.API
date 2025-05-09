using Dto.Model.Common;
using System.Collections.Generic;


namespace Dto.Model
{

    //---------------------------------------------------- Emergency Model-------------------------------------

   public class EmergencyModel :Response
    {
        public int EmergencyID { get; set; }
        public int UserID { get; set; }
        public  string PersonName { get; set; }
        public int  PhoneNumber { get; set; }
        public string Relation { get; set; }
    }

    //---------------------------------------------- Emergency Model List---------------------------------------------- 

    public class EmergencyModelView :Response
    {
        public List<EmergencyModel> EmergencyModelList { get; set; }
    }
}

