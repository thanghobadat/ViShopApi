using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using ViShopApi.ViewModel.Catalog.Category;
using ViShopApi.ViewModel.Common;

namespace ViShopApi.Client.Services
{
    public class CategoryApiClient : ICategoryApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CategoryApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ApiResult<bool>> CreateCategory(CategoryCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/Categories/CreateCategory", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResult<bool>>(result);
        }

        public async Task<ApiResult<bool>> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);


            var response = await client.DeleteAsync($"/api/Categories/DeleteCategory?id={id}");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResult<bool>>(result);
        }

        public async Task<ApiResult<CategoryViewModel>> GetById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);


            var response = await client.GetAsync($"/api/Categories/GetCategoryById?id={id}");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResult<CategoryViewModel>>(result);
        }

        public async Task<ApiResult<PageResult<CategoryViewModel>>> GetCategoryPagings(GetCategoryPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();

            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);


            var response = await client.GetAsync($"/api/Categories/GetCategoryPaging?pageIndex=" +
               $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}");

            var body = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<ApiResult<PageResult<CategoryViewModel>>>(body);
            return categories;
        }

        public async Task<ApiResult<bool>> UpdateCategory(CategoryViewModel request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/Categories/UpdateCategory", httpContent);
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ApiResult<bool>>(result);
        }
    }
}
