using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class EmployeePerformanceService : IEmployeePerformanceService
    {
        private readonly IEmployeePerformanceRepository _employeePerformanceRepository;
        public EmployeePerformanceService(IEmployeePerformanceRepository employeePerformanceRepository)
        {
            _employeePerformanceRepository = employeePerformanceRepository;
        }
        public Response EmployeePerformanceDelete(int id)
        {
            try
            {
                return _employeePerformanceRepository.EmployeePerformanceDelete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<EmployeePerformance> GetAll( int EmpID)
        {
            try
            {
                return _employeePerformanceRepository.GetAll(EmpID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EmployeePerformanceModel GetById(int id)
        {
            try
            {
                EmployeePerformanceModel employeePerformance = _employeePerformanceRepository.GetById(id);
                return employeePerformance;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Response SaveUpdate(EmployeePerformanceList employeePerformance)
        {
            try
            {
              

                DataTable AttributeData = new DataTable();
                AttributeData.Columns.Add("EmployeePerformanceId", typeof(int));
                AttributeData.Columns.Add("PerformanceAttributeId", typeof(int));
                AttributeData.Columns.Add("AttributeValue", typeof(string));
                AttributeData.Columns.Add("EmpID", typeof(int));
                AttributeData.Columns.Add("ToDate", typeof(DateTime));
                AttributeData.Columns.Add("FromDate", typeof(DateTime));
                AttributeData.Columns.Add("UserId", typeof(int));


                if (employeePerformance.Attribute.Count > 0)
                {
                    foreach (var item in employeePerformance.Attribute)
                    {

                        DataRow AttributeRow = AttributeData.NewRow();
                        AttributeRow["EmployeePerformanceId"] = item.EmployeePerformanceId;
                        AttributeRow["PerformanceAttributeId"] = item.PerformanceAttributeId;
                        AttributeRow["AttributeValue"] = item.AttributeValue;
                        AttributeRow["EmpID"] = item.EmpID;
                        AttributeRow["FromDate"] = item.FromDate;
                        AttributeRow["ToDate"] = item.ToDate;
                        AttributeRow["UserId"] = item.CreatedBy== null?0: item.CreatedBy;
                        AttributeData.Rows.Add(AttributeRow);
                        AttributeData.AcceptChanges();
                    }

                }





                return _employeePerformanceRepository.SaveUpdate(employeePerformance, AttributeData);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
