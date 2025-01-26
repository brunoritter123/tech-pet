using Microsoft.EntityFrameworkCore;
using Pressur.Data.Context;
using Pressur.Identity.Interfaces;
using Pressur.IntegrationTests.Seeds;

namespace Pressur.IntegrationTests.UseCase
{
    public class IntegrationTestsUseCase : IIntegrationTestsUseCase
    {
        private readonly PressurContext _context;
        private readonly IIdentityService _identityService;

        public IntegrationTestsUseCase(PressurContext context, IIdentityService identityService)
        {
            _context = context;
            _identityService = identityService;
        }

        public async Task ResetDataBaseAsync()
        {
            _context.Database.EnsureDeleted();
            _context.Database.Migrate();

            await _context.AddUsuarios(_identityService);

            await _context.SaveChangesAsync();
            return;
        }
    }
}
