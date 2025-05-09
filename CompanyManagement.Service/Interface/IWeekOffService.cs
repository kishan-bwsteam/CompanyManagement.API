using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
    public interface IWeekOffService
    {
        Response SaveUpdateWeakOfflDetail(WeakOffDetailModel model);
        Response SaveUpdateWeakOff(WeakOffModel model);
        WeakOffDetailViewModal GetAllWeakOffDetail(int CompanyID);
        WeakOffViewModal GetAllWeakOff(int CompanyID);
        Response DeleteWeakOff(int wkOffDetID);
        Response DeleteWeakOffDetail(int WeakOffDetailID);
        public WeakOffDetailViewModal GetSingleWeakOffDetail(int WeakOffDetailID);
             public WeakOffViewModal GetSingleWeakOff(int WeakOffID);
    }
}
