using Dto.Model;
using Dto.Model.Common;
using Dto.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Datas.Abstract
{
  public  interface IEmpEducationRepository
    {

        //-------------------------------------------------- Save And Education Details ------------------------------------------
        Response SaveOrUpdate(EducationModel education, int actionBy);


        //-------------------------------------- Get All Education Details by EducationViewModels --------------------------
        EducationViewModels GetAll();

        //----------------------------------------- Get Single Education List by UserID----------------------------------------- 

        singleEducationModel GetSingle(int userID);

        //--------------------------------------------- Delete Education List by UserID---------------------------------------------------

        EducationResponse Delete(int userID);

        IEnumerable<UserEducation> Get(DataTable filters, int limit, int startingRow);

    }
}
