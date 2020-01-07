using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace WebApiFunnyPlace.Models
{
    public partial class FunnyPlaceBetaContext : DbContext
    {
        public FunnyPlaceBetaContext()
        {
        }

        public FunnyPlaceBetaContext(DbContextOptions<FunnyPlaceBetaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UcatalogoSexo> UcatalogoSexo { get; set; }
        public virtual DbSet<UcatalogoStatus> UcatalogoStatus { get; set; }
        public virtual DbSet<UserOauthRegister> UserOauthRegister { get; set; }
        public virtual DbSet<UserRegister> UserRegister { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json")
                       .AddEnvironmentVariables()
                       .Build();

            if (!optionsBuilder.IsConfigured)
            {
                string conection = configuration["Data:DefaultConnection:ConnectionString"];
                optionsBuilder.UseSqlServer(conection);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<UcatalogoSexo>(entity =>
            {
                entity.ToTable("UCatalogoSexo");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCatStatusNavigation)
                    .WithMany(p => p.UcatalogoSexo)
                    .HasForeignKey(d => d.IdCatStatus)
                    .HasConstraintName("FK_UCatalogoSexo_UCatalogoStatus");
            });

            modelBuilder.Entity<UcatalogoStatus>(entity =>
            {
                entity.ToTable("UCatalogoStatus");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserOauthRegister>(entity =>
            {
                entity.ToTable("UserOAuthRegister");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdOauth).HasColumnName("idOAuth");

                entity.Property(e => e.LastName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Provider)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCatStatusNavigation)
                    .WithMany(p => p.UserOauthRegister)
                    .HasForeignKey(d => d.IdCatStatus)
                    .HasConstraintName("FK_UserOAuthRegister_UCatalogoStatus");
            });

            modelBuilder.Entity<UserRegister>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCumpleanios).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.HasOne(d => d.IdCatEstatusNavigation)
                    .WithMany(p => p.UserRegister)
                    .HasForeignKey(d => d.IdCatEstatus)
                    .HasConstraintName("FK_UserRegister_UCatalogoStatus");

                entity.HasOne(d => d.IdCatSexoNavigation)
                    .WithMany(p => p.UserRegister)
                    .HasForeignKey(d => d.IdCatSexo)
                    .HasConstraintName("FK_UserRegister_UCatalogoSexo");
            });
        }
    }
}
