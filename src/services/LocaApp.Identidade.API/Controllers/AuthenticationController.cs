using LocaApp.FrameWork.Controllers;
using LocaApp.FrameWork.Interfaces;
using LocaApp.Identidade.API.DTO;
using LocaApp.Identidade.API.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LocaApp.Identidade.API.Controllers
{
    [Route("api/identidade")]
    public class AuthenticationController : MainController
    {
        private readonly IAuthenticantionService _authenticantionService;
        public AuthenticationController(IAuthenticantionService authenticantionService, INotificador notificador) : base(notificador)
        {
            _authenticantionService = authenticantionService;
        }

        [HttpPost("nova-conta")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Registrar([FromBody] UsuarioRegistroDto usuarioRegistroDto)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            var resultado = await _authenticantionService.RegistroCliente(usuarioRegistroDto);

            return CustomResponse(resultado);
        }


        [HttpPost("autenticar")]
        public async Task<IActionResult> Autenticar(UsuarioLoginDto usuarioRegistroDto)
        {
            return Ok();
        }
    }
}
