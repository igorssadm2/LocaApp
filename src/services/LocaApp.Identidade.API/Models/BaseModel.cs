using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocaApp.Identidade.API.Models
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            Ativo = true;
            DataCadastrado = DateTime.Now;
        }

        [Column("DATA_CADASTRADO")]
        public DateTime DataCadastrado { get; set; }

        [Column("ATIVO")]
        public bool Ativo { get; set; }

    }
}
