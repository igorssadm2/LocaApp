using LocaApp.Identidade.API.Models.Cliente;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LocaApp.Identidade.API.Models.Endereco
{
    [Table("ENDERECO")]
    public class EnderecoModel : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_Endereco")]
        public Guid EnderecoId { get; set; }

        [Column("ID_Cliente")]
        public Guid ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual ClienteModel Cliente { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }
        [Column("CEP")]
        public string CEP { get; set; }
        [Column("Logradouro")]
        public string Logradouro { get; set; }
        [Column("Complemento")]
        public string Complemento { get; set; }
        [Column("Numero")]
        public string Numero { get; set; }
        [Column("Primario")]
        public bool Primario { get; set; }
    }
}
