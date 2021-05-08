using LocaApp.Identidade.API.Models.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocaApp.Identidade.API.Models
{
    public class LocaAppUserModel : IdentityUser
    {
        [Column("Type")]
        public TipoUsuario Tipo { get; set; }
        public string Matricula { get; set; }
    }
}
