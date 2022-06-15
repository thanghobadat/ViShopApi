using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViShopApi.Client.Services;
using ViShopApi.ViewModel.Catalog.Category;

namespace ViShopApi.Client.Controllers
{
    [Authorize]
    public class CategoryController : BaseController
    {
        private readonly ICategoryApiClient _categoryApiClient;

        public CategoryController(ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
        }
        public async Task<IActionResult> Index(GetCategoryPagingRequest request)
        {
            var response = await _categoryApiClient.GetCategoryPagings(request);
            if (!response.IsSuccessed)
            {
                throw new Exception(response.Message);
            }
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(response.ResultObj);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var response = await _categoryApiClient.CreateCategory(request);
            if (response.IsSuccessed)
            {
                TempData["result"] = "Create successfull";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", response.Message);


            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            if (id <= 0)
            {
                throw new Exception("id must be greater than 0");
            }
            var response = await _categoryApiClient.GetById(id);
            if (response.IsSuccessed)
            {
                var category = response.ResultObj;
                var updateRequest = new CategoryViewModel()
                {
                    Name = category.Name,
                    Description = category.Description,
                    Id = id
                };
                return View(updateRequest);
            }
            throw new Exception(response.Message);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryViewModel request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _categoryApiClient.UpdateCategory(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Update successfull";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }
        [Authorize(Roles = "admin")]
        //[HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id <= 0)
            {
                throw new Exception("id must be greater than 0");
            }

            var result = await _categoryApiClient.DeleteCategory(id);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Delete Successfull";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return RedirectToAction("Index");
        }
    }
}
