using Dto.Request;
using Dto.Responses;

namespace CompanyManagement.Services.Service.Abstract
{
    public interface ILoginService
    {
        LoginResponse Login(LoginRequest loginRequest);
    }
}
