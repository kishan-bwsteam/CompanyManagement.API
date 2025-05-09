using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Model
{
    public class CommonFunModel :Response
    {
        public int stateId { get; set; }

        public string StateName { get; set; }
        public int CountryId { get; set; }

        public string CountryName { get; set; }
    }


	//------------------------------------------ CountryDropdown Model List----------------------------------------
	public class CountryDropdown : Response
	{
		public List<CommonFunModel> dropdowncountry { get; set; }

	}

	//-----------------------------------StateDropdown Model List----------------------------------------
	public class StateDropdown : Response
	{
		public List<CommonFunModel> dropdownState { get; set; }
	}

}
