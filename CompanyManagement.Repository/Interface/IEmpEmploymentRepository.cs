using Dto.Model;
using Dto.Responses;


namespace Datas.Abstract
{
  public  interface IEmpEmploymentRepository
    {

        //--------------------------------------------- Save Update Employment ------------------------------------------------------------
        EmploymentResponse SaveUpdate(EmploymentModel model);


     
        //-------------------------------------- Get All Employement by AllEmploymentList----------------------------
        AllEmploymentList GetAll();


        //-------------------------------------------------- Get Single Employment data by userID-----------------------------
        SingleEmpModel GetSingle(int userID);

        //----------------------------------------------------------- Delete Employment by UserID------------------------------------


        EmploymentResponse Delete(int userID);


    }
}
