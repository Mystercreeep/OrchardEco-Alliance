using BannerWidgetModule.Models;
using BannerWidgetModule.Settings;
using BannerWidgetModule.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace BannerWidgetModule.Drivers
{
    public sealed class BannerWidgetModulePartDisplayDriver : ContentPartDisplayDriver<BannerWidgetModulePart>
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public BannerWidgetModulePartDisplayDriver(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public override IDisplayResult Display(BannerWidgetModulePart part, BuildPartDisplayContext context)
        {
            return Initialize<BannerWidgetModulePartViewModel>(GetDisplayShapeType(context), m => BuildViewModel(m, part, context))
                .Location("Detail", "Content:10")
                .Location("Summary", "Content:10");
        }

        public override IDisplayResult Edit(BannerWidgetModulePart part, BuildPartEditorContext context)
        {
            return Initialize<BannerWidgetModulePartViewModel>(GetEditorShapeType(context), model =>
            {
                model.Show = part.Show;
                model.ContentItem = part.ContentItem;
                model.BannerWidgetModulePart = part;
            });
        }

        public override async Task<IDisplayResult> UpdateAsync(BannerWidgetModulePart model, IUpdateModel updater)
        {
            await updater.TryUpdateModelAsync(model, Prefix, t => t.Show);

            return Edit(model);
        }

        private static void BuildViewModel(BannerWidgetModulePartViewModel model, BannerWidgetModulePart part, BuildPartDisplayContext context)
        {
            var settings = context.TypePartDefinition.GetSettings<BannerWidgetModulePartSettings>();

            model.ContentItem = part.ContentItem;
            model.MySetting = settings.MySetting;
            model.Show = part.Show;
            model.BannerWidgetModulePart = part;
            model.Settings = settings;
        }
    }
}
