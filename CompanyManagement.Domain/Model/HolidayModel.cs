using Dto.Model;
using System;

namespace CompanyManagement.Domain.Model
{
    public class HolidayModel
    {
        public int HolidayID { get; set; }
        public int CompanyID { get; set; }
        public DateTime HolidayDate { get; set; }
        public CompanyModel? Company { get; set; }
        public string HolidayName { get; set; }
    }
}