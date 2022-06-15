using ViShopApi.ViewModel.Common;

namespace ViShopApi.ViewModel.Catalog.Category
{
    public class GetCategoryPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

    }
}
