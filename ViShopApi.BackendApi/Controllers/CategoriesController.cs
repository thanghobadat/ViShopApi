using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ViShopApi.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetCompanyInformation(Guid companyId)
        {
            
            return Ok();
        }

    }
}
