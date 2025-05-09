using Dto.Model;
using Dto.Model.Common;
using Dto.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
    public interface IEmpEducationService
    {

        //-------------------------------------------------- Save And Education Details ------------------------------------------

        Response SaveUpdate(EducationModel model, int actionBy)
;

        //-------------------------------------- Get All Education Details by EducationViewModels --------------------------
        EducationViewModels GetAll();

        //----------------------------------------- Get Single Education List by UserID----------------------------------------- 

        singleEducationModel GetSingle(int userID);

        //--------------------------------------------- Delete Education List by UserID---------------------------------------------------

        EducationResponse Delete(int userID);
        IEnumerable<UserEducation> GetByUserId(int UserId);
    }
}
