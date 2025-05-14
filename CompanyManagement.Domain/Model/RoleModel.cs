using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
   public class RoleModel
    {
        public int RoleID { get; set; }

        public string RoleName { get; set; }
        public int RoleLevel { get; set; }
        public string Abbreviation { get; set; }
        public int userID { get; set; }
    }


    //-----------------------------------------Role Model List---------------------------------
    public class roleViewModels 
    {
        public List<RoleModel> roleViewModel { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }


    //-----------------------------------Single Model List-----------------------
    public class SingleRoleResponseModel 
    {
        public RoleModel RModel { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }
}

