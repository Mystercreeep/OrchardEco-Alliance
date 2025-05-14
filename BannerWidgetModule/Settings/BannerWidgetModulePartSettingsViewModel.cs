using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BannerWidgetModule.Settings
{
    public class BannerWidgetModulePartSettingsViewModel
    {
        public string MySetting { get; set; }

        [BindNever]
        public BannerWidgetModulePartSettings BannerWidgetModulePartSettings { get; set; }
    }
}
