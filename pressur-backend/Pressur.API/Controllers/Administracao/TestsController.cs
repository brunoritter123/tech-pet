// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.FeatureManagement.Mvc;
// using Pressur.Domain.Entities.Features;
// using Pressur.IntegrationTests.UseCase;
//
// namespace Pressur.API.Controllers
// {
//     [AllowAnonymous]
//     [ApiVersion("1.0")]
//     [Route("api/v{version:apiVersion}/[controller]")]
//     [ApiController]
//     public class TestsController : ControllerBase
//     {
//         [HttpPost("ResetDb")]
//         [ProducesResponseType(StatusCodes.Status204NoContent)]
//         [FeatureGate(FeatureFlags.ResetDB)]
//         public async Task<IActionResult> ResetarDb([FromServices] IIntegrationTestsUseCase useCase)
//         {
//             await useCase.ResetDataBaseAsync();
//             return NoContent();
//         }
//
//     }
// }
