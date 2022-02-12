using Microsoft.AspNetCore.Mvc;
using Shopping.Cliente.API.Application.Commands;
using Shopping.Cliente.API.Application.Identity;
using Shopping.Cliente.API.Models.Interfaces;
using Shopping.Cliente.API.Shared.Mediator;
using System;
using System.Threading.Tasks;

namespace Shopping.Cliente.API.Controllers
{
    public class ClientesController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _user;

        public ClientesController(IClienteRepository clienteRepository, IMediatorHandler mediator, IAspNetUser user)
        {
            _clienteRepository = clienteRepository;
            _mediator = mediator;
            _user = user;
        }

        [HttpGet("cliente/endereco")]
        public async Task<IActionResult> ObterEndereco()
        {
            var endereco = await _clienteRepository.ObterEnderecoPorId(_user.ObterUserId());

            return endereco == null ? NotFound() : CustomResponse(endereco);
        }

        [HttpPost("cliente/endereco")]
        public async Task<IActionResult> AdicionarEndereco(AdicionarEnderecoCommand endereco)
        {
            endereco.ClienteId = _user.ObterUserId();
            return CustomResponse(await _mediator.EnviarComando(endereco));
        }



        [HttpDelete("cliente/{idCliente}")]
        public async Task<IActionResult> RemoverCliente(Guid idCliente)
        {
            
            return null;
        }
    }
}
