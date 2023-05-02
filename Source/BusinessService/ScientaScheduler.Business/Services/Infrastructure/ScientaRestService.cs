using Newtonsoft.Json;
using ScientaScheduler.Business.Services.Interface;
using ScientaScheduler.Library.DTO;
using ScientaScheduler.Library.Responses;
using System.Net.Http.Headers;
using System.Text;

namespace ScientaScheduler.Business.Services.Infrastructure
{
    public class ScientaRestService : IScientaRestService
    {
        private readonly HttpClient httpClient = new();
        private readonly IConfiguration configuration;

        public ScientaRestService(IConfiguration configuration)
        {
            this.configuration = configuration;
            if (configuration is not null)
            {
                var url = configuration.GetSection("ScientaRestSettings").GetSection("BaseUrl").Value;
                if (url != null)
                {
                    httpClient.BaseAddress = new Uri(url);
                }
                var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(configuration["ScientaRestSettings:UserName"] + ":" + configuration["ScientaRestSettings:Password"]));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authString);
            }
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
        }

        public async Task<ScientaResponse<AktifGorevResponse>> ProjectList(ScieantaRestDTO restDTO)
        {
            ScientaResponse<AktifGorevResponse> aktifGorevListesi = new();
            string serializeProject = JsonConvert.SerializeObject(restDTO);
            StringContent stringContent = new StringContent(serializeProject, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("AktifGorevListesi", stringContent);
            if (response.IsSuccessStatusCode)
            {
                aktifGorevListesi.IsSuccess = true;
                var contentString = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentString))
                {
                    aktifGorevListesi.Data = JsonConvert.DeserializeObject<List<AktifGorevResponse>>(contentString);
                }
            }
            else
            {
                aktifGorevListesi.IsSuccess = false;
                aktifGorevListesi.ErrorCode = (int)response.StatusCode;
                aktifGorevListesi.ErrorMessage = response.ReasonPhrase;
            }
            return aktifGorevListesi;
        }
    }
}
