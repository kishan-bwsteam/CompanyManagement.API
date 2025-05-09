using Dto.Request;
using Dto.Responses;

namespace CompanyManagement.Data.Datas.Abstract
{
	public interface ILoginRepository
	{
		LoginResponse Login(LoginRequest loginRequest);
	}
}
