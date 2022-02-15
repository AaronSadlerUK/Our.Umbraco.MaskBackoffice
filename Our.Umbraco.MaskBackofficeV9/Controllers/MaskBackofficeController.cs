using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common.Controllers;

namespace Our.Umbraco.MaskBackofficeV9.Controllers;

public class MaskBackofficeController : UmbracoController
{
    private readonly IRuntimeState _runtimeState;

    public MaskBackofficeController(IRuntimeState runtimeState)
    {
        _runtimeState = runtimeState;
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
}