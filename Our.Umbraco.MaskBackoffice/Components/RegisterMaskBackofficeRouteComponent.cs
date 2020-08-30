using System;
using System.ComponentModel;
using System.Web.Mvc;
using System.Web.Routing;
using Our.Umbraco.MaskBackoffice.Controllers;
using Umbraco.Core.Configuration;
using Umbraco.Web.Editors;

namespace Our.Umbraco.MaskBackoffice.Components
{
    public class RegisterMaskBackofficeRouteComponent : IComponent, global::Umbraco.Core.Composing.IComponent
    {
        private readonly IGlobalSettings _globalSettings;

        public RegisterMaskBackofficeRouteComponent(IGlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;
        }

        public void Initialize()
        {
            if (AppSettingsManager.BackofficeMaskEnabled())
            {
                var routes = RouteTable.Routes;
                routes.RemoveAt(5);
                // Custom route to MyProductController which will use a node with a specific ID as the
                // IPublishedContent for the current rendering page
                //RouteTable.Routes.MapRoute(
                //    "Umbraco_back_office_Override",
                //    _globalSettings.GetUmbracoMvcArea() + "/{action}/{id}",
                //    new { controller = "MaskBackofficeRoute", action = "Default", id = UrlParameter.Optional });

                RouteTable.Routes.MapRoute(
                    "Umbraco_back_office",
                    _globalSettings.GetUmbracoMvcArea() + "/{action}/{id}",
                    new { controller = "BackOffice", action = "Default", id = UrlParameter.Optional },
                    //limit the action/id to only allow characters - this is so this route doesn't hog all other
                    // routes like: /umbraco/channels/word.aspx, etc...
                    new
                    {
                        action = @"[a-zA-Z]*",
                        id = @"[a-zA-Z]*",
                        _ = new DomainConstraint(AppSettingsManager.GetBackofficeDomain())
                    },
                    new[] { typeof(BackOfficeController).Namespace });

                RouteTable.Routes.MapRoute(
                    "Umbraco_back_office2",
                    _globalSettings.GetUmbracoMvcArea() + "/{action}/{id}",
                    new { controller = "MaskBackofficeRoute", action = "Default", id = UrlParameter.Optional },
                    new[] { typeof(MaskBackofficeRouteController).Namespace });
            }
        }

        public void Terminate()
        {
            // Nothing to terminate
        }

        public void Dispose()
        {
        }

        public ISite Site { get; set; }
        public event EventHandler Disposed;
    }
}
