using LocaApp.FrameWork.Controllers;
using LocaApp.FrameWork.Interfaces;
using LocaApp.Identidade.API.DTO;
using LocaApp.Identidade.API.Models.Enum;
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
        /// <summary>
        /// criar os usuarios do istema
        /// </summary>
        /// <param name="usuarioRegistroDto"></param>
        /// <returns>Token JWT</returns>
        [HttpPost("nova-conta")]
        [ProducesResponseType(typeof(UsuarioJwtDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Registrar([FromBody] UsuarioRegistroDto usuarioRegistroDto)
        {
            string resultado = string.Empty;
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }
            if (usuarioRegistroDto.TipoUsuario == TipoUsuario.GENERICO)
            {
                NotificarErro("Favor escolha um tipo de usuário");
            }
            if (usuarioRegistroDto.TipoUsuario == TipoUsuario.CLIENTE)
                resultado = await _authenticantionService.RegistroCliente(usuarioRegistroDto);

            if (usuarioRegistroDto.TipoUsuario == TipoUsuario.OPERADOR)
                resultado = await _authenticantionService.RegistroOperador(usuarioRegistroDto);

            var JWT = await _authenticantionService.GerarJwt(new UsuarioLoginDto() { Email=usuarioRegistroDto.Email, Senha = usuarioRegistroDto.Senha});

            return CustomResponse(JWT);
        }

        /// <summary>
        /// Motor para gerar  token de autenticação
        /// </summary>
        /// <param name="usuarioLoginDto"></param>
        /// <param name="tipoUsuario"></param>
        /// <returns>Token JWT</returns>
        [ProducesResponseType(typeof(UsuarioJwtDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [HttpPost("gerar-token")]
        public async Task<IActionResult> GerarToken([FromBody] UsuarioLoginDto usuarioLoginDto, TipoUsuario tipoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            var resultado = await _authenticantionService.GerarJwt(usuarioLoginDto);

            return CustomResponse(resultado);
        }
        //[HttpPost("gerar-token")]
        //[ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]

        //public async Task<IActionResult> CadastrarPerfil([FromBody] UsuarioRegistroDto usuarioRegistroDto, TipoUsuario tipoUsuario)
        //{
        //    string resultado = string.Empty;
        //    if (!ModelState.IsValid)
        //    {
        //        return CustomResponse(ModelState);
        //    }
        //    if (tipoUsuario == TipoUsuario.CLIENTE)
        //        resultado = await _authenticantionService.RegistroCliente(usuarioRegistroDto);

        //    else if (tipoUsuario == TipoUsuario.OPERADOR)
        //        resultado = await _authenticantionService.RegistroOperador(usuarioRegistroDto);

        //    return CustomResponse(resultado);
        //}
    }
}
