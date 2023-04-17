using ScientaScheduler.Library.DTO;

namespace ScientaScheduler.Business.Services.Interface
{
    public interface IUserService
    {
        Task<string> CreateToken(UserLoginResponseDTO userLoginRequest);
        Task<UserLoginResponseDTO> UserLogin(UserLoginRequestDTO userLoginInfo);
    }
}
