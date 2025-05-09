

using Dto.Model;

namespace Datas.Abstract
{
 public interface ICommonRepository
    {

        //-------------------------------------------Get Country Dropdown-------------------------------------------------------
        CountryDropdown GetCountry();

        //------------------------------------------- Get State Dropdown -------------------------------------------------------
        StateDropdown GetState();
        //CommonFunModel
    }
}
