using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Our.Umbraco.MaskBackofficeV9.Controllers;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Hosting;
using Umbraco.Cms.Web.Common.ApplicationBuilder;
using Umbraco.Extensions;

namespace Our.Umbraco.MaskBackofficeV9.Composers;

public class OverrideBackofficeRoute : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.Configure<UmbracoPipelineOptions>(options =>
        {
            options.AddFilter(new UmbracoPipelineFilter(nameof(MaskBackofficeController))
            {
                Endpoints = app => app.UseEndpoints(endpoints =>
                {
                    var globalSettings = app.ApplicationServices
                        .GetRequiredService<IOptions<GlobalSettings>>().Value;
                    var hostingEnvironment = app.ApplicationServices
                        .GetRequiredService<IHostingEnvironment>();
                    var rootSegment = $"{globalSettings.GetBackOfficePath(hostingEnvironment)}";
                    endpoints.MapUmbracoRoute<MaskBackofficeController>(
                        rootSegment,
                        Constants.Web.Mvc.BackOfficeArea,
                        string.Empty,
                        "Default",
                        includeControllerNameInRoute: false,
                        constraints:

                        // Limit the action/id to only allow characters - this is so this route doesn't hog all other
                        // routes like: /umbraco/channels/word.aspx, etc...
                        // (Not that we have to worry about too many of those these days, there still might be a need for these constraints).
                        new
                        {
                            action = @"[a-zA-Z]*",
                            id = @"[a-zA-Z]*"
                        });
                })
            });
        });
    }
}