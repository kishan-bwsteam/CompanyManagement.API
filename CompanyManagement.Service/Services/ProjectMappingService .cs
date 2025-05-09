using Datas.Abstract;
using Datas.Concrete;
using Dto.Model.Common;
using Service.Abstract;
using SqlDapper.Concrete;
using System;
using System.Data;

namespace Service.Concrete
{
    public class ProjectMappingService : IProjectMappingService
    {



        private readonly IProjectMappingRepository _iProjectMappingRepository;

       public ProjectMappingService(IProjectMappingRepository iProjectMappingRepository)
        {
            _iProjectMappingRepository = iProjectMappingRepository;
        }

        //--------------------------------------Save Update Project Mapping-----------------------



        public Response SaveUpdateMapping(MultipleMappingView projectmapping)
        {
            try
            {
                DataTable MappingProject = new DataTable();
                MappingProject.Columns.Add("ProjectMappingID", typeof(int));
                MappingProject.Columns.Add("UserID", typeof(int));
                MappingProject.Columns.Add("UserName", typeof(string));
                MappingProject.Columns.Add("ProjectID", typeof(int));
                MappingProject.Columns.Add("ProjectName", typeof(string));
                MappingProject.Columns.Add("CompanyID", typeof(int));
                if (projectmapping.EmployeeMapppingList.Count>0)
                {
                    foreach(var item in projectmapping.EmployeeMapppingList)
                    {

                        DataRow MappingProjectRow = MappingProject.NewRow();
                        MappingProjectRow["ProjectMappingID"] = item.ProjectMappingID;
                        MappingProjectRow["UserID"] = item.UserID;
                        MappingProjectRow["UserName"] = item.EmployeeName;
                        MappingProjectRow["ProjectID"] = item.ProjectID;
                        MappingProjectRow["ProjectName"] = item.ProjectName;
                        MappingProjectRow["CompanyID"] = item.CompanyID;
                        MappingProject.Rows.Add(MappingProjectRow);
                        MappingProject.AcceptChanges();
                    }
                }

                return _iProjectMappingRepository.SaveUpdateMapping( MappingProject);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }





        //--------------------------------------Get All Project List---------------------------


     


        public MultipleMappingView GetAllProjectList(int CompanyID)
        {
            try
            {
                return _iProjectMappingRepository.GetAllProjectList(CompanyID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }




        public MultipleMappingView GetAllProjectMapping(int CompanyID, int ProjectID)
        {
            try
            {
                return _iProjectMappingRepository.GetAllProjectMapping(CompanyID,ProjectID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }
}
