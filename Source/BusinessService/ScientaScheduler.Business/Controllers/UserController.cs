using Microsoft.AspNetCore.Mvc;
using ScientaScheduler.Business.Services.Interface;
using ScientaScheduler.Library.DTO;

namespace ScientaScheduler.Business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("UserLogin")]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginRequestDTO userLogin)
        {
            var userInfo = await userService.UserLogin(userLogin);
            if (userInfo != null)
            {
                if (userInfo.IsSuccessful)
                {
                    var token = await userService.CreateToken(userInfo);
                    return Ok(token);
                }
                else
                {
                    return NotFound(userInfo.ErrorMessage);
                }
            }
            else
            {
                return BadRequest(new UserLoginResponseDTO { IsSuccessful=false, ErrorMessage="Login olurken hata meydana geldi"});
            }                
        }

        
    }
}
