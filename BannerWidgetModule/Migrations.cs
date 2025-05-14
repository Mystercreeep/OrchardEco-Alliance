using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Data.Migration;
using OrchardCore.ContentFields.Settings;
using OrchardCore.Media.Fields;
using OrchardCore.ContentFields.Fields;
using OrchardCore.Widgets.Models;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Media.Settings;
using OrchardCore.ContentManagement.Metadata.Builders; 


namespace BannerWidgetModule
{
    public class Migrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public Migrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public async Task<int> CreateAsync()
        {
            // Crée et configure le part BannerPart
            await _contentDefinitionManager.AlterPartDefinitionAsync("BannerPart", part => part
                .Attachable()
                .WithField("Image", field => field.OfType("MediaField")
                    .WithDisplayName("Image de la bannière")
                    .WithSettings(new MediaFieldSettings { Multiple = false,
                        AllowedExtensions = new[] { "*" }  
                    })
                .WithField("Text", field => field.OfType("TextField")
                    .WithDisplayName("Texte de la bannière")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "Texte à superposer sur l'image."  // guillemets doubles
                    })
            )));

            // Crée et configure le type BannerWidget comme Widget
            await _contentDefinitionManager.AlterTypeDefinitionAsync("BannerWidget", type => type
                .DisplayedAs("Banner Widget")
                .WithPart("Widget")
                .WithPart("BannerPart")
                .WithSettings(new ContentTypeSettings { Stereotype = "Widget" })
            );

            // Retourne la version du schéma
            return 1;
        }
    }
}
