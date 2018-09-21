using Paulo.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Paulo.Data.EntitiesConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            Property(p => p.CPF)
                .IsRequired();

            Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(256);

            Property(u => u.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

            // Mapeia essa entidade com a entidade do Identity
            ToTable("AspNetUsers");
        }
    }
}
