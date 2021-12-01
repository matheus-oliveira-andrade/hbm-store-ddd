using HBMStore.Catalogo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HBMStore.Catalogo.Data.Mappings
{
    // fluent API
    public partial class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(c => c.Imagem)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.OwnsOne(c => c.Dimensoes, cm =>
            {
                cm.Property(c => c.Altura)
                .HasColumnName("Altura")
                .HasColumnType("int");

                cm.Property(c => c.Largura)
                .HasColumnName("Largura")
                .HasColumnType("int");

                cm.Property(c => c.Profundidade)
                .HasColumnName("Profundidade")
                .HasColumnType("int");
            });

            builder.ToTable("Produtos");

        }
    }
}
