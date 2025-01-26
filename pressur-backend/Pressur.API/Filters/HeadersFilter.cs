using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Pressur.API.Filters
{
    public class HeadersFilter : IActionFilter
    {
        private string? _correlationId = Guid.NewGuid().ToString();

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("x-correlation-id"))
                context.HttpContext.Request.Headers.Append("x-correlation-id", _correlationId);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            if (!context.HttpContext.Request.Headers.ContainsKey("x-correlation-id"))
                context.HttpContext.Request.Headers.Append("x-correlation-id", _correlationId);
            else
                _correlationId = context.HttpContext.Request.Headers["x-correlation-id"];
        }
    }
}
