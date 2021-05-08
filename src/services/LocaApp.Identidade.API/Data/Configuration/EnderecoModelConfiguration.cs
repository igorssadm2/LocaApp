using LocaApp.Identidade.API.Models.Cliente;
using LocaApp.Identidade.API.Models.Endereco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocaApp.Identidade.API.Data.Configuration
{
    internal class EnderecoModelConfiguration : IEntityTypeConfiguration<EnderecoModel>
    {
        public void Configure(EntityTypeBuilder<EnderecoModel> builder)
        {
            builder.ToTable("ENDERECO");
            builder.HasKey(p => p.EnderecoId);
            builder.Property(p => p.EnderecoId).HasColumnName("Id_Endereco").ValueGeneratedOnAdd();
            builder.Property(p => p.ClienteId).HasColumnName("ID_Cliente");
            builder.Property(p => p.Nome).HasColumnName("Nome");
            builder.Property(p => p.CEP).HasColumnName("CEP");
            builder.Property(p => p.Complemento).HasColumnName("Complemento");
            builder.Property(p => p.Numero).HasColumnName("Numero");
            builder.Property(p => p.Primario).HasColumnName("Primario");
            builder.Property(p => p.DataCadastrado).HasColumnName("DataCasdastro");
            builder.Property(p => p.Ativo).HasColumnName("Ativo");

            builder.HasOne(e => e.Cliente)
            .WithMany(c => c.Enderecos)
            .HasForeignKey(e => e.ClienteId)
            .OnDelete(DeleteBehavior.NoAction);

        }

    }
}
