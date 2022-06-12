using TechPet.Application.Abstractions;

namespace TechPet.Application.Commands.IncluirUsers
{
    public interface IIncluirUsersCommand : ICommand<bool, IEnumerable<IncluirUsersCommandRequest>>
    {
    }
}

