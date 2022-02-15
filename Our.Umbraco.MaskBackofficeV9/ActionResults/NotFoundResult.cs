using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Our.Umbraco.MaskBackofficeV9.ActionResults
{
    /// <summary>
    /// Returns the Umbraco not found result
    /// </summary>
    public class NotFoundResult : IActionResult
    {
        private readonly string _message;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundResult"/> class.
        /// </summary>
        public NotFoundResult(string message = null)
        {
            _message = message;
        }

        /// <inheritdoc/>
        public async Task ExecuteResultAsync(ActionContext context)
        {
            HttpResponse response = context.HttpContext.Response;

            response.Clear();

            response.StatusCode = StatusCodes.Status404NotFound;

            var viewResult = new ViewResult
            {
                ViewName = "~/umbraco/UmbracoWebsite/NotFound.cshtml"
            };
            
            await viewResult.ExecuteResultAsync(context);
        }
    }
}