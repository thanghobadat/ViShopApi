﻿using Microsoft.AspNetCore.Mvc;
using ViShopApi.ViewModel.Common;

namespace ViShopApi.Client.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
