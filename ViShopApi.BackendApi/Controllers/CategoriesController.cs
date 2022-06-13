using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ViShopApi.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        //[HttpGet("GetAllCategory")]
        //public async Task<IActionResult> GetAllCategory(int id)
        //{
            
        //    return Ok();
        //}

    }
}
