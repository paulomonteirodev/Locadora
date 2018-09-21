using Paulo.Data.Entities;
using Paulo.Data.EntitiesConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Paulo.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            :base("AppDbContext")
        {
        }

        // Registro das entidades
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Filme> Filme { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Locacao> Locacao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remover configuração pra não deixar remover em cascata
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Remover configuração de plurização das entidades
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Registro da configuração do usuário pra de adaptar a Entidade do Identity
            modelBuilder.Configurations.Add(new UsuarioConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
