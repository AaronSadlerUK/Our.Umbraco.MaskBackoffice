using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Our.Umbraco.MaskBackofficeV9.Configurations;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Configuration.Grid;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.Hosting;
using Umbraco.Cms.Core.Manifest;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Core.Serialization;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.WebAssets;
using Umbraco.Cms.Infrastructure.WebAssets;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.BackOffice.Security;

namespace Our.Umbraco.MaskBackofficeV9.Controllers;

public class MaskBackofficeController : BackOfficeController
{
    private readonly IRuntimeState _runtimeState;
    private readonly OurUmbracoMaskBackoffice _config;
    
    /// <summary>
    /// Before the controller executes we will handle redirects and not founds
    /// </summary>
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (_runtimeState.Level == RuntimeLevel.Run && _config.Enabled && _config.Domains != null && _config.Domains.Any() && !_config.Domains.Contains(context.HttpContext.Request.Host.Value))
        {
            if (_config.UseRedirect && !string.IsNullOrEmpty(_config.RedirectUrl) && !string.IsNullOrWhiteSpace(_config.RedirectUrl))
            {
                context.Result = Redirect(_config.RedirectUrl);
            }
            else
            {
                context.Result = new ActionResults.NotFoundResult(_config);   
            }
        }
        else
        {
            await base.OnActionExecutionAsync(context, next);
        }
    }

    public MaskBackofficeController(IBackOfficeUserManager userManager, IRuntimeState runtimeState,
        IRuntimeMinifier runtimeMinifier, IOptions<GlobalSettings> globalSettings,
        IHostingEnvironment hostingEnvironment, ILocalizedTextService textService, IGridConfig gridConfig,
        BackOfficeServerVariables backOfficeServerVariables, AppCaches appCaches,
        IBackOfficeSignInManager signInManager, IBackOfficeSecurityAccessor backofficeSecurityAccessor,
        ILogger<MaskBackofficeController> logger, IJsonSerializer jsonSerializer,
        IBackOfficeExternalLoginProviders externalLogins, IHttpContextAccessor httpContextAccessor,
        IBackOfficeTwoFactorOptions backOfficeTwoFactorOptions, IManifestParser manifestParser,
        ServerVariablesParser serverVariables, IOptions<SecuritySettings> securitySettings, IOptions<OurUmbracoMaskBackoffice> config) 
        : base(userManager,
        runtimeState, runtimeMinifier, globalSettings, hostingEnvironment, textService, gridConfig,
        backOfficeServerVariables, appCaches, signInManager, backofficeSecurityAccessor, logger, jsonSerializer,
        externalLogins, httpContextAccessor, backOfficeTwoFactorOptions, manifestParser, serverVariables,
        securitySettings)
    {
        _runtimeState = runtimeState;
        _config = config.Value;
    }
}