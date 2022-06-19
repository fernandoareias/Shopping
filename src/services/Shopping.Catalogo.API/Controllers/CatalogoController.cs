using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.Catalogo.API.Models;
using Shopping.Catalogo.API.Models.Interfaces;
using Shopping.Core.WebAPI.Identidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Catalogo.API.Controllers
{
    [Authorize]
    [Route("api/catalogo")]
    [ApiController]
    public class CatalogoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public CatalogoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [AllowAnonymous]
        [HttpGet("produtos")]
        public async Task<IEnumerable<Produto>> Index()
        {
            return await _produtoRepository.ObterTodosAsync();
        }

        [ClaimsAuthorize("Catalogo", "ler")]
        [HttpGet("produtos/{id}")]
        public async Task<Produto> ProdutoDetalhe(Guid id)
        {
            return await _produtoRepository.ObterPorId(id);
        }
    }
}
