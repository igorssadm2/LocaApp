
using LocaApp.Identidade.API.Models.Endereco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LocaApp.Identidade.API.Models.Cliente
{
    [Table("CLIENTE")]
    public class ClienteModel : BaseModel
    {
        public ClienteModel()
        {
            Ativo = true;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_Cliente")]
        public Guid ClienteId { get; set; }

        [Column("Id_Usuario")]
        public Guid UsuarioId { get; set; }

        [Column("Nome_Completo")]
        public string NomeCompleto { get; set; }

        [Column("Telefone")]
        public string Telefone { get; set; }

        [Column("Cpf")]
        public string Cpf { get; set; }

        [Column("Email")]
        public string Email { get; set; }
        [Column("Data_Nascimento")]
        public DateTime DataNascimento { get; set; }
        public virtual IReadOnlyCollection<EnderecoModel> Enderecos { get; set; }

    }
}
