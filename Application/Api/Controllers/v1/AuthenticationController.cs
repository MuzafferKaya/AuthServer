﻿using DomainService.Abstrack;
using Dto.Request.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateToken([FromBody] AuthenticationRequest request)
        {            
            var response = await _authenticationService.CreateTokenAsync(request);
            return Ok(response);
        }
    }
}
