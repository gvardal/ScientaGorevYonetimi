using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ScientaScheduler.Business.Services.Interface;
using ScientaScheduler.Library.DTO;

namespace ScientaScheduler.Business.Services.Infrastructure
{
    public class UserService : IUserService
    {
        private HttpClient httpClient = new();
        readonly IConfiguration configuration;
        private string UserAuth { get; set; }

        public UserService(IConfiguration configuration)
        {
            this.configuration = configuration;
            if (configuration is not null)
            {
                var url = configuration.GetSection("ScientaRestSettings").GetSection("BaseUrl").Value;
                if (url != null)
                {
                    httpClient.BaseAddress = new Uri(url);
                }                
            }            
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
        }   

        public async Task<UserLoginResponseDTO> UserLogin(UserLoginRequestDTO userLoginRequest)
        {
            UserLoginResponseDTO userInfoDTO = new();
            UserAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{configuration["ScientaRestSettings:UserName"]}:{configuration["ScientaRestSettings:Password"]}"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", UserAuth);
            string userInfo = JsonConvert.SerializeObject(userLoginRequest);
            StringContent stringContent = new StringContent(userInfo, Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await httpClient.PostAsync("login", stringContent);
            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();
                string[] loginKeys = contentString.Split(new char[] { '$' });
                userInfoDTO.IsSuccessful = true;
                userInfoDTO.CalisanID = Convert.ToInt32(loginKeys[0]);
                userInfoDTO.UserName = loginKeys[1];
                userInfoDTO.GirisAnahtari = loginKeys[3];
            }
            else
            {
                userInfoDTO.IsSuccessful = false;
                var contentString = await response.Content.ReadAsStringAsync();
                userInfoDTO.ErrorMessage = contentString;
            }
            return userInfoDTO;
        }

        public Task<string> CreateToken(UserLoginResponseDTO userLoginRequest)
        {
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(configuration["TokenSettings:SecurityKey"]!));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                    issuer: configuration["TokenSettings:Issuer"],
                    audience: configuration["TokenSettings:Audience"],
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddMinutes(Convert.ToInt32(configuration["TokenSettings:AccessTokenExpirationMin"])),
                    signingCredentials: signingCredentials,
                    claims: SetClaims(userLoginRequest)
                ) ;
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return Task.FromResult(handler.WriteToken(token));
        }

        private IEnumerable<Claim> SetClaims(UserLoginResponseDTO userLoginRequest)
        {
            var claims = new List<Claim>()
            {
                new Claim("CalisanID",userLoginRequest.CalisanID.ToString(),ClaimValueTypes.Integer64),
                new Claim("userFullName",userLoginRequest.UserName,ClaimValueTypes.String),
                new Claim("GirisAnahtari",userLoginRequest.GirisAnahtari,ClaimValueTypes.String),

            };
            return claims;
        }

        public bool ValidateToken(string token)
        {
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(configuration["TokenSettings:SecurityKey"]!));
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, new TokenValidationParameters()
                {
                    IssuerSigningKey = key,
                    ValidIssuer= configuration["TokenSettings:Issuer"],
                    ValidAudience = configuration["TokenSettings:Audience"],
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                }, out SecurityToken validatedToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
