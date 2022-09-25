using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Prometheus;
using TechPet.Identity.Interfaces;

namespace TechPet.API.Filters
{
    public class MetricsFilter : IActionFilter
    {
        private readonly IJwtService _jwtService;
        private static readonly Counter RequestCountByMethod = Metrics.CreateCounter("contar_requests_total", "Quantidade de requisições por empresa, por empresa.",
        new CounterConfiguration
        {
            LabelNames = new[] { "Empresa" }
        });

        public MetricsFilter(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var empresa = _jwtService.GetUserData();
            if (empresa != null)
                RequestCountByMethod.WithLabels(empresa).Inc();
        }
    }
}
