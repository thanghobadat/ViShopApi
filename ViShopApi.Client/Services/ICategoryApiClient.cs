using ViShopApi.ViewModel.Catalog.Category;
using ViShopApi.ViewModel.Common;

namespace ViShopApi.Client.Services
{
    public interface ICategoryApiClient
    {
        Task<ApiResult<PageResult<CategoryViewModel>>> GetCategoryPagings(GetCategoryPagingRequest request);
        Task<ApiResult<bool>> CreateCategory(CategoryCreateRequest request);
        Task<ApiResult<CategoryViewModel>> GetById(int id);
        Task<ApiResult<bool>> UpdateCategory(CategoryViewModel request);
        Task<ApiResult<bool>> DeleteCategory(int id);
    }
}
