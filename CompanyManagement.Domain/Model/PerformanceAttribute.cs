
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Model
{
    public class PerformanceAttribute
    {
        public int PerformanceAttributeId { get; set; }
        public string AttributeName { get; set; }
        public int CompanyID { get; set; }
        public int DataTypeId { get; set; }
        public int MaxNumber { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }
    

    }
    public class PerformanceAttributeModel:Response
    {
        public PerformanceAttribute SinglePerformanceAttributeList { get; set; }
    }


    public class PerformanceAttributeView : Response
    {
        public List<PerformanceAttribute> PerformanceAttributesList { get; set; }
    }


    public class DataTypeModel:Response
    {
        public int DataTypeId { get; set; }
        public string TypeName { get; set; }
    }
   


    public class DataTypeView : Response
    {
        public List<DataTypeModel> DataTypeList { get; set; }
    }



}
