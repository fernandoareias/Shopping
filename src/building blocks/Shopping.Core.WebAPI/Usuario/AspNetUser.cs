﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Shopping.WebAPI.Core.Usuario
{
    public class AspNetUser : IAspNetUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public Guid ObterUserId()
            => EstaAutenticado() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.Empty;
        
        public string ObterUserEmail()
            => EstaAutenticado() ? _accessor.HttpContext.User.GetUserEmail() : "";

        public string ObterUserToken()
            => EstaAutenticado() ? _accessor.HttpContext.User.GetUserToken() : "";

        public bool EstaAutenticado()
            => _accessor.HttpContext.User.Identity.IsAuthenticated;

        public bool PossuiRole(string role)
            => _accessor.HttpContext.User.IsInRole(role);
        
        public IEnumerable<Claim> ObterClaims()
            => _accessor.HttpContext.User.Claims;
        
        public HttpContext ObterHttpContext()
            => _accessor.HttpContext;
    }
}