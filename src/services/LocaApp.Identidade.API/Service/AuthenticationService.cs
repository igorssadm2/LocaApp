using LocaApp.FrameWork.Interfaces;
using LocaApp.FrameWork.Services;
using LocaApp.Identidade.API.Data;
using LocaApp.Identidade.API.DTO;
using LocaApp.Identidade.API.Models;
using LocaApp.Identidade.API.Models.Enum;
using LocaApp.Identidade.API.Service.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocaApp.Identidade.API.Service
{
    public class AuthenticationService : BaseService, IAuthenticantionService
    {
        private readonly UserManager<LocaAppUserModel> _userManager;
        private readonly SignInManager<LocaAppUserModel> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IJWTService _JWTService;


        public AuthenticationService(UserManager<LocaAppUserModel> userManager,
            SignInManager<LocaAppUserModel> signInManager,
            IJWTService jWTService,
            ApplicationDbContext context, INotificador notificador) : base(notificador)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _JWTService = jWTService;
            _context = context;
        }

        private async Task<bool> EmailExiste(string Email)
        {
            var usuarioExiste = await _userManager.FindByEmailAsync(Email);
            
            return usuarioExiste != null ? true : false;
        }

        public async Task<UsuarioJwtDto> GerarJwt(UsuarioLoginDto usuarioLoginDto)
        {
            if (await EmailExiste(usuarioLoginDto.Email))
            {

            }
            var result = await _signInManager.PasswordSignInAsync(usuarioLoginDto.Email, usuarioLoginDto.Senha,
                false, true);

            if (result.Succeeded)
            {
                return await _JWTService.GerarJwt(usuarioLoginDto.Email);
            }

            if (result.IsLockedOut)
            {
                Notificar("Usuário temporariamente bloqueado por tentativas inválidas");
                return null;
            }

            Notificar("Usuário e/ou senha incorretos");
            return null;
        }
        public async Task<string> RegistroCliente(UsuarioRegistroDto usuarioRegistroDto)
        {
            try
            {

                if (await EmailExiste(usuarioRegistroDto.Email))
                {
                    Notificar("Email já cadastrado");
                    return string.Empty;

                }

                var user = new LocaAppUserModel
                {
                    UserName = usuarioRegistroDto.Email,
                    Email = usuarioRegistroDto.Email,
                    EmailConfirmed = true,
                    Tipo = TipoUsuario.CLIENTE
                };

                var result = await _userManager.CreateAsync(user, usuarioRegistroDto.Senha);

                if (!result.Succeeded)
                {
                    result.Errors?.ToList().ForEach((n) => Notificar($"codErro - {n.Code}  | descrErro - {n.Description}"));
                    return string.Empty;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                //Notificar(ex.Data. Errors.Select(x => x.Description).ToList().ToString());

                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<string> RegistroOperador(UsuarioRegistroDto usuarioRegistroDto)
        {
            try
            {
                if (string.IsNullOrEmpty(usuarioRegistroDto.Matricula))
                {
                    Notificar("Campo matrícula é obrigatorio para cadastro de operador");
                    return string.Empty;
                }

                if (await EmailExiste(usuarioRegistroDto.Email))
                {
                    Notificar("Email já cadastrado");
                    return string.Empty;
                }

                var user = new LocaAppUserModel
                {
                    UserName = usuarioRegistroDto.Email,
                    Email = usuarioRegistroDto.Email,
                    EmailConfirmed = true,
                    Tipo = TipoUsuario.OPERADOR
                };

                var result = await _userManager.CreateAsync(user, usuarioRegistroDto.Senha);

                if (!result.Succeeded)
                {
                    Notificar(result.Errors.Select(x => x.Description).ToList().ToString());
                    return string.Empty;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                //Notificar(ex.Data. Errors.Select(x => x.Description).ToList().ToString());

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
