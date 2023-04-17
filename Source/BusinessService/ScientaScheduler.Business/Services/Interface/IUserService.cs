using ScientaScheduler.Library.DTO;

namespace ScientaScheduler.Business.Services.Interface
{
    public interface IUserService
    {
        Task<UserLoginResponseDTO> UserLogin(UserLoginRequestDTO userLoginRequest);
    }
}
