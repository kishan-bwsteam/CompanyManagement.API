using Dto.Model.Common;

using System.Collections.Generic;


namespace Dto.Model
{

    //------------------------------------- Education Model -------------------------------------------
    public class EducationModel
    {
        public int UserID { get; set; }
        public string DegreeName { get; set; }
        public string InstName { get; set; }
        public DateTime PassingYear { get; set; }
        public decimal Percentage { get; set; }
        public int EducationId { get; set; }


    }

    //------------------------------------------ Education Model List--------------------------------------------------------

    public class EducationViewModels : Response 
    { 
    public List<EducationModel> EducationViewModel { get; set; }
    }

    //----------------------------------------- Education Single Model List-----------------------------------------------------


    public class singleEducationModel : Response
    { 
    public EducationModel SingleEducationList { get; set; }
    }
}
