using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using TechPet.API.Responses;

namespace TechPet.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var response = new ErrorResponse(context.Exception);
            context.Result = new ContentResult
            {
                Content = JsonConvert.SerializeObject(response),
                StatusCode = 500,
                ContentType = "application/json"
            };

            _logger.LogError(context.Exception, "Erro inesperado na requisição");
        }
    }
}
