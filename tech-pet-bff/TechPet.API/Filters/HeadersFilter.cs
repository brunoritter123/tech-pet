using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TechPet.API.Filters
{
    public class HeadersFilter : IActionFilter
    {
        private string correlationId = Guid.NewGuid().ToString();

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("x-correlation-id"))
                context.HttpContext.Request.Headers.Add("x-correlation-id", correlationId);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            if (!context.HttpContext.Request.Headers.ContainsKey("x-correlation-id"))
                context.HttpContext.Request.Headers.Add("x-correlation-id", correlationId);
            else
                correlationId = context.HttpContext.Request.Headers["x-correlation-id"];
        }
    }
}
