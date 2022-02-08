﻿using Microsoft.AspNetCore.Mvc;
using Shopping.Identidade.API.Models;
using Shopping.Identidade.API.Models.Interfaces;
using Shopping.Identidade.API.Shared.Notification;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Identidade.API.Controllers
{
    [Route("api/authentication")]
    public class IdentityController : MainController
    {

        private readonly IIdentityService _identityService;
        private readonly INotification _notificationService;
        public IdentityController(IIdentityService identity, INotification notificationService)
        {
            _identityService = identity;
            _notificationService = notificationService;
        }


        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar([FromBody]UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var response = _identityService.Registro(usuarioRegistro);

            if(response == null && _notificationService.Erros.Any())
            {
                return BadRequest(_notificationService.Erros);
            }

            return Ok(response);
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult> Login(UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var response = _identityService.Login(usuarioLogin);

            if (response == null && _notificationService.Erros.Any())
            {
                return BadRequest(_notificationService.Erros);
            }

            return Ok(response);
        }
    }
}