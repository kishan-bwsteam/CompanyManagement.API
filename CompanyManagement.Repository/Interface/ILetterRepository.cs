using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datas.Abstract
{
    public interface ILetterRepository
    {
        //-------------------------------------------------Save Update Letter Template ------------------------------ 

        Response SaveUpdate(LetterModel model);

        //---------------------------------------------Get All Letter Template By LetterViewModel------------------
        LetterViewModel GetAll(int companyID);

        //--------------------------------------------- Get  Single Template (List) by EmpID-----------------------

        SingleLetterViewModel GetSingle(int letterID);

        //-------------------------------------------- Delete Template by EmpID----------------------------------

        Response Delete(int letterID);

      
    }
}
