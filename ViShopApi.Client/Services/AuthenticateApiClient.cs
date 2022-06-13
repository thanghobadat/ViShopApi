using Newtonsoft.Json;
using System.Text;
using ViShopApi.ViewModel.Authenticate;
using ViShopApi.ViewModel.Common;

namespace ViShopApi.Client.Services
{
    public class AuthenticateApiClient : IAuthenticateApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthenticateApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<ApiResult<string>> Login(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PostAsync("/api/authenticates/login", httpContent);
            var token = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResult<string>>(token);
        }

        //public async Task<ApiResult<bool>> RegisterUser(RegisterRequest registerRequest)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    client.BaseAddress = new Uri("https://localhost:5001");

        //    var json = JsonConvert.SerializeObject(registerRequest);
        //    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

        //    var response = await client.PostAsync($"/api/authenticates/register", httpContent);
        //    var result = await response.Content.ReadAsStringAsync();
        //    return JsonConvert.DeserializeObject<ApiResult<bool>>(result);


        //}
    }
}
