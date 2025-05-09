using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Model
{
    public class WeakOffModel
    {
        public int WeakOffID { get; set; }
        public int NOOfWeekOff { get; set; }
        public long CompanyID { get; set; }
        public long CreatedBy { get; set; }
        public int WkOffDetID { get; set; }


        public List<WeakOffDetailModel> WeakOffDetailModel { get; set; }

        // public int DayID { get; set; }
        // public int WeekNumber { get; set; }
    }
    public class WeakOffViewModal : Response
    {
        public List<WeakOffModel> WeakOffModelList { get; set; }
    }

    public class WeakOffDetailModel
    {
        public int WkOffDetID { get; set; }
        public string Day { get; set; }
        public bool Week1 { get; set; }
        public bool Week2 { get; set; }
        public bool Week3 { get; set; }
        public bool Week4 { get; set; }
        public bool Week5 { get; set; }
        
    }

    public class WeakOffDetailViewModal : Response
    {
        public List<WeakOffDetailModel> weakOffDetailModel { get; set; }
    }
}
