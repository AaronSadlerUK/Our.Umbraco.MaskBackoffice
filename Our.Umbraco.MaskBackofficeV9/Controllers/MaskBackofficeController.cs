using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Our.Umbraco.MaskBackofficeV9.Controllers;

public class MaskBackofficeController : UmbracoController
{
    private readonly IRuntimeState _runtimeState;
    private readonly IUmbracoContextFactory _umbracoContextFactory;

    public MaskBackofficeController(IRuntimeState runtimeState, IUmbracoContextFactory umbracoContextFactory)
    {
        _runtimeState = runtimeState;
        this._umbracoContextFactory = umbracoContextFactory;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Default()
    {
        // Check if we not are in an run state, if so we need to redirect
        if (_runtimeState.Level != RuntimeLevel.Run)
        {
            return Redirect("/");
        }

        return NotFound();
    }
    
    /// <summary>
        /// Before the controller executes we will handle redirects and not founds
        /// </summary>
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        context.Result = new Our.Umbraco.MaskBackofficeV9.ActionResults.NotFoundResult();
    }
}