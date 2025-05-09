using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Model
{
    //-------------------------------- Letter Model -------------------------------

  public  class LetterModel :Response
    {
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public string TempleteName { get; set; }
        public string Body { get; set; }
        public int LetterID { get; set; }

        public int IsDeleted { get; set; }
        public int UpdatedBy { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedOn { get; set; }
        public int CreatedOn { get; set; }
    }

    //----------------------------------------------------- Letter Model List-------------------------------------------------------



    public class LetterViewModel : Response
    {
        public List<LetterModel> LetterModelList { get; set; }
    }


    //---------------------------------------------------Single Model List------------------------------------------------------


    public class SingleLetterViewModel : Response
    {
        public LetterModel SingleModelList { get; set; }
    }
}
