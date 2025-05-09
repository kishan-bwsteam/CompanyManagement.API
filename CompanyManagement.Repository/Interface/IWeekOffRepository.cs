using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Datas.Abstract
{
    public interface IWeekOffRepository
    {
        Response SaveUpdateWeakOffDetail(WeakOffDetailModel model);
        Response SaveUpdateWeakOff(WeakOffModel model,DataTable dt);
        WeakOffDetailViewModal GetAllWeakOffDetail(int CompanyID);
        WeakOffViewModal GetAllWeakOff(int CompanyID);

        Response DeleteWeakOff(int wkoffid);
        Response DeleteWeakOffDetail(int WeakOffDetailID);
        public WeakOffDetailViewModal GetSingleWeakOffDetail(int WeakOffDetailID);
        public WeakOffViewModal GetSingleWeakOff(int WeakOffID);
    }
}
