using LocaApp.Identidade.API.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocaApp.Identidade.API.Controllers
{
    public class AuthenticationController : Controller
    {
    [Route("api/Authentication")]

        public async IActionResult RegistrarUsuario(UsuarioRegistroDto usuarioRegistroDto)
        {
            return await Task.FromResult(0);
        }
    }
}
