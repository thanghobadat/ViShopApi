using ViShopApi.ViewModel.Catalog.Category;
using ViShopApi.ViewModel.Common;

namespace ViShopApi.Application.Catalog
{
    public interface ICategoryService
    {
        Task<ApiResult<PageResult<CategoryViewModel>>> GetCategoryPaging(GetCategoryPagingRequest request);
        Task<ApiResult<bool>> CreateCategory(CategoryCreateRequest request);
        Task<ApiResult<bool>> UpdateCategory(CategoryViewModel request);

        Task<ApiResult<bool>> DeleteCategory(int id);
        Task<ApiResult<CategoryViewModel>> GetById(int id);


    }
}
