using Dto.Model;
using Dto.Model.Common;


namespace Datas.Abstract
{
    public interface IEmailMassagesRepository
    {

        //-------------------------------------------------Save Update Email message ------------------------------ 

        Response SaveUpdate(EmailMassagesModel model);


        //---------------------------------------------Get All Email Message By EmailMessagesViewModel------------------

        EmailMessagesViewModel GetAll(int UserID);

        //---------------------------------------------Get All Email Message By EmailMessagesViewModel------------------

        EmailMessagesViewModel GetAllCompanyMail(int CompanyID);

        //--------------------------------------------- Get  Single Message (List) by EmpID-----------------------

        SingleEmailMassagesViewModel GetSingle(int empID);

        //-------------------------------------------- Delete Email Message by EmpID----------------------------------
        Response Delete(int empID);

    }
}
