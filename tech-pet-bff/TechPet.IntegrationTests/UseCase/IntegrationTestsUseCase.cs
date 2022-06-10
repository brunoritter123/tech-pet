using Microsoft.EntityFrameworkCore;
using TechPet.Data.Context;
using TechPet.Identity.Interfaces;
using TechPet.IntegrationTests.Seeds;

namespace TechPet.IntegrationTests.UseCase
{
    public class IntegrationTestsUseCase : IIntegrationTestsUseCase
    {
        private readonly TechPetContext _context;
        private readonly IIdentityService _identityService;

        public IntegrationTestsUseCase(TechPetContext context, IIdentityService identityService)
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
