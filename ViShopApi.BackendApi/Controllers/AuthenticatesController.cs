using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViShopApi.Application.Authenticate;
using ViShopApi.ViewModel.Authenticate;

namespace ViShopApi.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticatesController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        public AuthenticatesController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var resultToken = await _authenticateService.Login(request);
            return Ok(resultToken);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authenticateService.Register(request);
            return Ok(result);
        }
    }
}
