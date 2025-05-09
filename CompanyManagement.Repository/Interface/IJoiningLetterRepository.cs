using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datas.Abstract
{
   public interface IJoiningLetterRepository
    {
        Response SaveUpdate();
        SingleLetterViewModel GetSingleLetterByTemplate(string TemplateName, int CompanyID);
    }
}
