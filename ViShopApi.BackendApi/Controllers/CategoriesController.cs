using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViShopApi.Application.Catalog;
using ViShopApi.ViewModel.Catalog.Category;

namespace ViShopApi.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetCategoryPaging")]
        public async Task<IActionResult> GetCategoryPaging([FromQuery] GetCategoryPagingRequest request)
        {
            var categories = await _categoryService.GetCategoryPaging(request);
            return Ok(categories);
        }
        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetById(id);
            return Ok(category);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateRequest request)
        {

            var result = await _categoryService.CreateCategory(request);
            return Ok(result);
        }
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryViewModel request)
        {
            var result = await _categoryService.UpdateCategory(request);
            return Ok(result);
        }
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategory(id);
            return Ok(result);
        }

    }
}
