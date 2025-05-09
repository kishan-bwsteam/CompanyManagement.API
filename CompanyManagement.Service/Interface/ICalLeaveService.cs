

using Dto.Model;

namespace Service.Abstract
{
    public interface ICalLeaveService

    {


        //---------------------------------------Calaculate leave by CalLeaveViewModel-------------------
        CalLeaveViewModel GetLeave(RequestLeave model);
    }
}
