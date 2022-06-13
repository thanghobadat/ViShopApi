using ViShopApi.ViewModel.Authenticate;
using ViShopApi.ViewModel.Common;

namespace ViShopApi.Client.Services
{
    public interface IAuthenticateApiClient
    {
        Task<ApiResult<string>> Login(LoginRequest request);
        //Task<ApiResult<bool>> RegisterUser(RegisterRequest registerRequest);


    }
}
