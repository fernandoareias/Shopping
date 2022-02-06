using FluentValidation.Results;
using Shopping.Cliente.API.Shared.Commands;
using Shopping.Cliente.API.Shared.Messages;
using System.Threading.Tasks;

namespace Shopping.Cliente.API.Shared.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}
