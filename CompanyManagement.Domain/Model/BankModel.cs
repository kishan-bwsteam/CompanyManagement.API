using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Model
{

//-------------------------------Bank Model-------------------------------------
    public class BankModel
    {
        public int BankDetailID { get; set; }
        public int UserID { get; set; }
        public string BankName { get; set; }
        public long AccountNo { get; set; }
        public string IFSCCode { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

    }

    //-------------------------------Bank Model List-------------------------------------

    public class BankViewModels : Response
    {
        public List<BankModel> banklist { get; set; }
    }
}
