using Dto.Model;

namespace Datas.Abstract
{
    public interface ICalLeaveRepository
    {


        //---------------------------------------Calaculate leave by CalLeaveViewModel-------------------
        CalLeaveViewModel GetLeave(RequestLeave model);
    }
}
