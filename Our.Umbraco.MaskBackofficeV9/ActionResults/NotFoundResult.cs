using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Our.Umbraco.MaskBackofficeV9.Configurations;

namespace Our.Umbraco.MaskBackofficeV9.ActionResults
{
    /// <summary>
    /// Returns the Our Umbraco MaskBackoffice not found result
    /// </summary>
    public class NotFoundResult : IActionResult
    {
        private readonly string _message;
        private readonly OurUmbracoMaskBackoffice _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundResult"/> class.
        /// </summary>
        /// 

        public NotFoundResult(OurUmbracoMaskBackoffice config, string message = null)
        {
            _config = config;
            _message = message;
        }
        
        public new async Task ExecuteResultAsync(ActionContext context)
        {
            HttpResponse response = context.HttpContext.Response;

            response.Clear();

            response.StatusCode = StatusCodes.Status404NotFound;

            var viewResult = new ViewResult
            {
                ViewName = $"~/Views/{_config.ViewName}"
            };
            
            await viewResult.ExecuteResultAsync(context);
        }
    }
}