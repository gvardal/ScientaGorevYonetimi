using ScientaScheduler.Library.DTO;
using ScientaScheduler.Library.Responses;

namespace ScientaScheduler.Blazor.Services.Interface
{
    public interface IBusinessService
    {
        Task<UserLoginResponse> UserLogin(UserLoginRequestDTO userLoginRequest);
    }
}
