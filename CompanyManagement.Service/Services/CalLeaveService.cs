using Authentication.DataManager.Helper;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Service.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Concrete
{
    public class CalLeaveService : ICalLeaveService
    {
        EncryptHelperObj obj = new EncryptHelperObj();

        private readonly ICalLeaveRepository _iattendanceRepository;


        public CalLeaveService(ICalLeaveRepository _attendanceRepository)
        {
            _iattendanceRepository = _attendanceRepository;
        }



        //---------------------------- calculate Leave by CalLeaveViewModel----------------



        public CalLeaveViewModel GetLeave(RequestLeave model)
        {
            try
            {
                return _iattendanceRepository.GetLeave(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
