using FCG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCG.Infrastructure.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.SenhaHash)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.Role)
                .IsRequired();

            builder.Property(u => u.StatusConta)
                .IsRequired();

            builder.HasMany(u => u.Biblioteca)
                .WithOne(b => b.Usuario)
                .HasForeignKey(b => b.UsuarioId);
        }
    }
}