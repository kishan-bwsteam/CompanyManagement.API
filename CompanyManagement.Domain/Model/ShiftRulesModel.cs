using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Model
{
    public class ShiftRulesModel 
    {
        public int ShiftRuleId { get; set; }
        public int FullDay { get; set; }
        public int HalfDay { get; set; }
        public int OneFourthDay { get; set; }
        public int Absent { get; set; }
        public int HolidayAsAbsent { get; set; }
        public int AbsentIfLateFor { get; set; }
        public string ShiftConsider { get; set; }
        public int MinOT { get; set; }
        public int MaxOT { get; set; }
        public int Wage { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string MarkAbsent { get; set; }

    }

    public class AllShiftRulesModel : Response
    {
        public List<ShiftRulesModel> shiftRulesModels { get; set; }
    }
}
