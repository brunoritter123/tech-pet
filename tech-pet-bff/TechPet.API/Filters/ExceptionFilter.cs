using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TechPet.API.Results;
using Newtonsoft.Json;

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
            var result = new ResultDefault<string>(context.Exception.Message);
            context.Result = new ContentResult
            {
                Content = JsonConvert.SerializeObject(result),
                StatusCode = 500,
                ContentType = "application/json"
            };

            _logger.LogError(context.Exception, "Erro inesperado na requisição");
        }
    }
}
