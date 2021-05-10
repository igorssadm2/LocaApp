using LocaApp.Identidade.API.DTO;
using LocaApp.Identidade.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LocaApp.Identidade.API.Service.Interface
{
    public interface IJWTService
    {
        Task<UsuarioJwtDto> GerarJwt(string email);
        Task<ClaimsIdentity> ObterClaimsUsuario(ICollection<Claim> claims, LocaAppUserModel user);
    }
}
