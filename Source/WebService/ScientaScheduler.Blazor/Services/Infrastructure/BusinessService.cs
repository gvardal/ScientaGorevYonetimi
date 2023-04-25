using Newtonsoft.Json;
using ScientaScheduler.Blazor.Services.Interface;
using ScientaScheduler.Library.DTO;
using ScientaScheduler.Library.Responses;
using System.Net.Http.Headers;
using System.Text;

namespace ScientaScheduler.Blazor.Services.Infrastructure
{
    public class BusinessService : IBusinessService
    {
        private HttpClient httpClient;
        private readonly IConfiguration configuration;

        public BusinessService(IConfiguration configuration)
        {
            this.configuration = configuration;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(configuration["ScientaSchedulerBusinessSettings:BaseUrl"]!);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<UserLoginResponse> UserLogin(UserLoginRequestDTO userLoginRequest)
        {
            UserLoginResponse userLogin = new();
            string userInfo = JsonConvert.SerializeObject(userLoginRequest);
            StringContent stringContent = new StringContent(userInfo, Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await httpClient.PostAsync("api/User/UserLogin", stringContent);            
            if(response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();
                userLogin.IsSuccess = true;
                userLogin.Token = contentString;
            }
            else
            {
                var contentString = await response.Content.ReadAsStringAsync();
                userLogin.IsSuccess = false;
                userLogin.ErrorMessage = contentString;
            }
            return userLogin;
        }
    }
}
