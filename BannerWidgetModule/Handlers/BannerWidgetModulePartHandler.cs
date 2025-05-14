using BannerWidgetModule.Models;
using OrchardCore.ContentManagement.Handlers;
using System.Threading.Tasks;

namespace BannerWidgetModule.Handlers
{
    public class BannerWidgetModulePartHandler : ContentPartHandler<BannerWidgetModulePart>
    {
        public override Task InitializingAsync(InitializingContentContext context, BannerWidgetModulePart part)
        {
            part.Show = true;

            return Task.CompletedTask;
        }
    }
}