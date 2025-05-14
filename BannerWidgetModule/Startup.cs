using BannerWidgetModule.Drivers;
using BannerWidgetModule.Handlers;
using BannerWidgetModule.Models;
using BannerWidgetModule.Settings;
using BannerWidgetModule.ViewModels;
using Fluid;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;

namespace BannerWidgetModule
{
    public sealed class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TemplateOptions>(o =>
            {
                o.MemberAccessStrategy.Register<BannerWidgetModulePartViewModel>();
            });

            services.AddContentPart<BannerWidgetModulePart>()
                .UseDisplayDriver<BannerWidgetModulePartDisplayDriver>()
                .AddHandler<BannerWidgetModulePartHandler>();

            services.AddScoped<IContentTypePartDefinitionDisplayDriver, BannerWidgetModulePartSettingsDisplayDriver>();
            services.AddDataMigration<Migrations>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "BannerWidgetModule",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }

}
