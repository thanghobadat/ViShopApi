using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViShopApi.ViewModel.Authenticate;
using ViShopApi.ViewModel.Common;

namespace ViShopApi.Application.Authenticate
{
    public interface IAuthenticateService
    {
        Task<ApiResult<string>> Login(LoginRequest request);
        Task<ApiResult<bool>> Register(RegisterRequest request);
    }
}
