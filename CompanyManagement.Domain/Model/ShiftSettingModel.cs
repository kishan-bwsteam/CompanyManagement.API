
using System.Collections.Generic;

namespace Dto.Model.Common
{

    //--------------------------------------Shift Setting Model----------------------------
    public class ShiftSettingModel
    {
        public long ShiftID { get; set; }
        public string ShiftName { get; set; }
        public string ToTime { get; set; }
        public string FromTime { get; set; }
        public long CompanyID { get; set; }
        public long CreatedBy { get; set; }

    }

    //--------------------------------------Shift Setting Model List----------------------------
    public class ShiftSettingViewModel : Response
    {
        public List<ShiftSettingModel> shiftSettingModalList { get; set; }
    }
    public class SingleShiftSettingModel : Response
    {

        public List<ShiftSettingModel> singleShiftSettingModal { get; set; }
    }
}