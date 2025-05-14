using BannerWidgetModule.Models;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System;
using System.Threading.Tasks;

namespace BannerWidgetModule.Settings
{
    public sealed class BannerWidgetModulePartSettingsDisplayDriver : ContentTypePartDefinitionDisplayDriver
    {
        public override IDisplayResult Edit(ContentTypePartDefinition contentTypePartDefinition, IUpdateModel updater)
        {
            if (!string.Equals(nameof(BannerWidgetModulePart), contentTypePartDefinition.PartDefinition.Name))
            {
                return null;
            }

            return Initialize<BannerWidgetModulePartSettingsViewModel>("BannerWidgetModulePartSettings_Edit", model =>
            {
                var settings = contentTypePartDefinition.GetSettings<BannerWidgetModulePartSettings>();

                model.MySetting = settings.MySetting;
                model.BannerWidgetModulePartSettings = settings;
            }).Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentTypePartDefinition contentTypePartDefinition, UpdateTypePartEditorContext context)
        {
            if (!string.Equals(nameof(BannerWidgetModulePart), contentTypePartDefinition.PartDefinition.Name))
            {
                return null;
            }

            var model = new BannerWidgetModulePartSettingsViewModel();

            await context.Updater.TryUpdateModelAsync(model, Prefix, m => m.MySetting);

            context.Builder.WithSettings(new BannerWidgetModulePartSettings { MySetting = model.MySetting });

            return Edit(contentTypePartDefinition, context.Updater);
        }
    }
}
