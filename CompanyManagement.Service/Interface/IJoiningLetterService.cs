using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
    public interface IJoiningLetterService
    {
        Response GenerateLetter(JoiningLetterModel model);
    }
}
