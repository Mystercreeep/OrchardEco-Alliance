using BannerWidgetModule.Models;
using BannerWidgetModule.Settings;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;

namespace BannerWidgetModule.ViewModels
{
    public class BannerWidgetModulePartViewModel
    {
        public string MySetting { get; set; }

        public bool Show { get; set; }

        [BindNever]
        public ContentItem ContentItem { get; set; }

        [BindNever]
        public BannerWidgetModulePart BannerWidgetModulePart { get; set; }

        [BindNever]
        public BannerWidgetModulePartSettings Settings { get; set; }
    }
}
