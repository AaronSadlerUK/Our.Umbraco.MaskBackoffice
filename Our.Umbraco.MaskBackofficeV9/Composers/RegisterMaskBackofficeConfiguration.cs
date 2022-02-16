using Microsoft.Extensions.DependencyInjection;
using Our.Umbraco.MaskBackofficeV9.Configurations;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Our.Umbraco.MaskBackofficeV9.Composers;

public class RegisterMaskBackofficeConfiguration : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.Configure<OurUmbracoMaskBackoffice>(
            builder.Config.GetSection("OurUmbracoMaskBackoffice"));
    }
}