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
        private readonly ApplicationDbContext _context;



        public AuthenticationService(UserManager<LocaAppUserModel> userManager,
            ApplicationDbContext context, INotificador notificador) : base(notificador)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<bool> EmailExiste(UsuarioRegistroDto usuarioRegistroDto)
        {
            var usuarioExiste = await _userManager.FindByEmailAsync(usuarioRegistroDto.Email);

            return usuarioExiste != null ? true : false;
        }


        public async Task<string> RegistroCliente(UsuarioRegistroDto usuarioRegistroDto)
        {
            try
            {

                if (await EmailExiste(usuarioRegistroDto))
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

                if (await EmailExiste(usuarioRegistroDto))
                {
                    Notificar("Email já cadastrado");
                    return string.Empty;

                }

                var user = new LocaAppUserModel
                {
                    UserName = usuarioRegistroDto.Email,
                    Email = usuarioRegistroDto.Email,
                    EmailConfirmed = true,
                    Tipo = TipoUsuario.GENERICO
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
