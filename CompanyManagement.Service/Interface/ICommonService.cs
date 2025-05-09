



using Dto.Model;

namespace Service.Abstract
{
    public interface ICommonService
    {
        //-------------------------------------------Get Country Dropdown-------------------------------------------------------
        CountryDropdown GetCountry();

        //------------------------------------------- Get State Dropdown -------------------------------------------------------
        StateDropdown GetState();
        //CommonFunModel
    }
}
