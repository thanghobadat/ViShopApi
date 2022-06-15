using Microsoft.EntityFrameworkCore;
using ViShopApi.Data.EF;
using ViShopApi.Data.Enities;
using ViShopApi.ViewModel.Catalog.Category;
using ViShopApi.ViewModel.Common;

namespace ViShopApi.Application.Catalog
{
    public class CategoryService : ICategoryService
    {
        private readonly ViShopDbContext _context;
        public CategoryService(ViShopDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> CreateCategory(CategoryCreateRequest request)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Name.Contains(request.Name));

            if (category != null)
            {
                return new ApiErrorResult<bool>("Category is exist");
            }

            category = new Category()
            {
                Name = request.Name,
                Description = request.Description
            };
            await _context.Categories.AddAsync(category);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Create unsuccessful");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return new ApiErrorResult<bool>("Category doesn't exist");
            }

            _context.Categories.Remove(category);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Category has been deleted before please check again");
            }
            return new ApiSuccessResult<bool>(true);
        }

        public async Task<ApiResult<CategoryViewModel>> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return new ApiErrorResult<CategoryViewModel>("Category doesn't exits");
            }

            var categoryViewModel = new CategoryViewModel()
            {
                Id = id,
                Name = category.Name,
                Description = category.Description
            };
            return new ApiSuccessResult<CategoryViewModel>(categoryViewModel);
        }

        public async Task<ApiResult<PageResult<CategoryViewModel>>> GetCategoryPaging(GetCategoryPagingRequest request)
        {
            var query = await _context.Categories.ToListAsync();
            var ListCategorys = query.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                ListCategorys = ListCategorys.Where(x => x.Name.Contains(request.Keyword));
            }


            int totalRow = ListCategorys.Count();

            var data = ListCategorys.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToList();

            var pagedResult = new PageResult<CategoryViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            return new ApiSuccessResult<PageResult<CategoryViewModel>>(pagedResult);
        }

        public async Task<ApiResult<bool>> UpdateCategory(CategoryViewModel request)
        {
            if (await _context.Categories.AnyAsync(x => x.Name == request.Name && x.Id != request.Id))
            {
                return new ApiErrorResult<bool>("Category is exist");
            }

            var category = await _context.Categories.FindAsync(request.Id);

            category.Name = request.Name;
            category.Description = request.Description;

            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Please change data");
            }

            return new ApiSuccessResult<bool>(true);
        }
    }
}
