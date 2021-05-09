using LocaApp.Identidade.API.DTO;
using LocaApp.Identidade.API.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocaApp.Identidade.API.Service.Interface
{
    public interface IAuthenticantionService
    {
        Task<string> RegistroCliente(UsuarioRegistroDto usuarioRegistroDto);
        Task<string> RegistroOperador(UsuarioRegistroDto usuarioRegistroDto);

        Task<bool> EmailExiste(UsuarioRegistroDto usuarioRegistroDto);


    }
}
