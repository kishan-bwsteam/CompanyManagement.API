using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Service.Concrete
{
   public class WeekOffService : IWeekOffService
    {
        //EncryptHelperObj obj = new EncryptHelperObj();
       
        private readonly IWeekOffRepository _IWeekOffRepository;


        public WeekOffService(IWeekOffRepository weekOffRepository)
        {
            _IWeekOffRepository = weekOffRepository;
        }
        public Response SaveUpdateWeakOfflDetail(WeakOffDetailModel model)
        {
            try
            {
                return _IWeekOffRepository.SaveUpdateWeakOffDetail( model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Response SaveUpdateWeakOff(WeakOffModel model)
        {
            WeakOffModel weakOff = new WeakOffModel();
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("WkOffDetID", typeof(long));
                dt.Columns.Add("DayID", typeof(int));
                dt.Columns.Add("WeakNumber1", typeof(int));
                dt.Columns.Add("WeakNumber2", typeof(int));
                dt.Columns.Add("WeakNumber3", typeof(int));
                dt.Columns.Add("WeakNumber4", typeof(int));
                dt.Columns.Add("WeakNumber5", typeof(int));
         
                if (model.WeakOffDetailModel.Count > 0)
                {

                    foreach (var item in model.WeakOffDetailModel)
                    {
                        DataRow dr = dt.NewRow();
                        dr["WkOffDetID"] = weakOff.WkOffDetID;
                        dr["DayID"] = item.Day;
                        dr["WeakNumber1"] = item.Week1;
                        dr["WeakNumber2"] = item.Week2;
                        dr["WeakNumber3"] = item.Week3;
                        dr["WeakNumber4"] = item.Week4;
                        dr["WeakNumber5"] = item.Week5;
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }
                }
                return _IWeekOffRepository.SaveUpdateWeakOff(model,dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public WeakOffDetailViewModal GetAllWeakOffDetail(int CompanyID)
        {
            try
            {
                return _IWeekOffRepository.GetAllWeakOffDetail(CompanyID);
            }

            catch (Exception ex)
            {
                return null;
            }
        }


        public WeakOffViewModal GetAllWeakOff(int CompanyID)
        {
            try
            {
                return _IWeekOffRepository.GetAllWeakOff(CompanyID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }




        public WeakOffDetailViewModal GetSingleWeakOffDetail(int WeakOffDetailID)
        {
            try
            {
                return _IWeekOffRepository.GetSingleWeakOffDetail(WeakOffDetailID);
            }

            catch (Exception ex)
            {
                return null;
            }
        }
        public WeakOffViewModal GetSingleWeakOff(int WeakOffID)
        {
            try
            {
                return _IWeekOffRepository.GetSingleWeakOff(WeakOffID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Response DeleteWeakOff(int wkOffDetID)
        {
            try
            {
                return _IWeekOffRepository.DeleteWeakOff(wkOffDetID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Response DeleteWeakOffDetail(int WeakOffDetailID)
        {
            try
            {
                return _IWeekOffRepository.DeleteWeakOffDetail(WeakOffDetailID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
