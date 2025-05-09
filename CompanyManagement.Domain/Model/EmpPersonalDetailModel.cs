using Dto.Model.Common;
using System;
using System.Collections.Generic;

namespace Dto.Model
{

	//------------------------------------------- Personal Details Model------------------------------------------------------

     public class EmpPersonalDetailModel: Response
    {
        public int EmpID { get; set; }
        public int EmployeeStatusID { get; set; }
        public int CompanyID { get; set; }
		public int UserID { get; set; }
		public int LoginUserID { get; set; }
		public string UserGuid { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime CreatedOn { get; set; }
	    public int DepartmentID { get; set; }
        public int RoleID { get; set; }
        public long PrimaryPhoneNo { get; set; }
        public long SecondaryPhoneNo { get; set; }
        public string MiddleName { get; set; }
		
		public string UserName { get; set; }
		public int UserTypeID { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime UpdatedOn { get; set; }
		public int UpdatedBy { get; set; }
		public int CreatedBy { get; set; }
		public int PassKeyId { get; set; }
		public string PassKey { get; set; }
		public string SaltKey { get; set; }
		public string SaltKeyIV { get; set; }
		public string EmailID { get; set; }
		public bool IsPrimary { get; set; }
	


		public int EmpCode { get; set; }
        public DateTime DOH { get; set; }
         public DateTime DOB { get; set; }

        public string BloodGroup { get; set; }


    }

	//------------------------------------------------ Personal Details Model List-------------------------------------

	public class EmpPersonalDetailViewModels : Response
	{
		public List<EmpPersonalDetailModel> PersonalDetailModelList { get; set; }
	}

	//------------------------------------------------ Personal Details Single Model List-------------------------------------

	public class SinglePersonalDetailResponseModel : Response
	{
		public List<EmpPersonalDetailModel> SingleModelList { get; set; }
	}

	//------------------------------------------------ Department Dropdown Details Model -------------------------------------
	public class DepartmentDropdown : Response
	{
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

    }

	//------------------------------------------------ Department Dropdown Details Model List -------------------------------------
	public class DepartmentViewModel : Response
	{
		public List<DepartmentDropdown> DepartmentList { get; set; }
    }



	//------------------------------------------------ Position Dropdown Details Model -------------------------------------
	public class PositionDropDown : Response
	{
       public int RoleID { get; set; }
        public string PositionName { get; set; }
    }



	//------------------------------------------------ Position Dropdown Details Model List -------------------------------------
	public class PositionViewModel : Response
	{ 
	public List<PositionDropDown> PositionList { get; set; }
	}
}
