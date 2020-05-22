using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataBase.DataModels
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doente> Doente { get; set; }
        public virtual DbSet<Hospital> Hospital { get; set; }
        public virtual DbSet<Internamento> Internamento { get; set; }
        public virtual DbSet<Modulos> Modulos { get; set; }
        public virtual DbSet<PerfilUtilizador> PerfilUtilizador { get; set; }
        public virtual DbSet<Permissoes> Permissoes { get; set; }
        public virtual DbSet<ProfissionaisDeSaude> ProfissionaisDeSaude { get; set; }
        public virtual DbSet<Teste> Teste { get; set; }
        public virtual DbSet<Utilizador> Utilizador { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=diogo");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Doente>(entity =>
            {
                entity.HasKey(e => e.IdDoente);

                entity.ToTable("doente", "diogo");

                entity.HasIndex(e => e.IdUtilizador)
                    .HasName("ID_Utilizador");

                entity.Property(e => e.IdDoente)
                    .HasColumnName("ID_Doente")
                    .HasColumnType("int(10)");

                entity.Property(e => e.IdUtilizador)
                    .HasColumnName("ID_Utilizador")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Regiao)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUtilizadorNavigation)
                    .WithMany(p => p.Doente)
                    .HasForeignKey(d => d.IdUtilizador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doente_ibfk_1");
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.HasKey(e => e.IdHospital);

                entity.ToTable("hospital", "diogo");

                entity.Property(e => e.IdHospital)
                    .HasColumnName("ID_Hospital")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Distrito)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Internamento>(entity =>
            {
                entity.HasKey(e => e.IdInternamento);

                entity.ToTable("internamento", "diogo");

                entity.HasIndex(e => e.IdDoente)
                    .HasName("ID_Doente");

                entity.HasIndex(e => e.IdHospital)
                    .HasName("ID_Hospital");

                entity.Property(e => e.IdInternamento)
                    .HasColumnName("ID_Internamento")
                    .HasColumnType("int(10)");

                entity.Property(e => e.DataAlta)
                    .HasColumnName("Data_Alta")
                    .HasColumnType("date");

                entity.Property(e => e.DataInternamento)
                    .HasColumnName("Data_Internamento")
                    .HasColumnType("date");

                entity.Property(e => e.IdDoente)
                    .HasColumnName("ID_Doente")
                    .HasColumnType("int(10)");

                entity.Property(e => e.IdHospital)
                    .HasColumnName("ID_Hospital")
                    .HasColumnType("int(10)");

                entity.HasOne(d => d.IdDoenteNavigation)
                    .WithMany(p => p.Internamento)
                    .HasForeignKey(d => d.IdDoente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("internamento_ibfk_1");

                entity.HasOne(d => d.IdHospitalNavigation)
                    .WithMany(p => p.Internamento)
                    .HasForeignKey(d => d.IdHospital)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("internamento_ibfk_2");
            });

            modelBuilder.Entity<Modulos>(entity =>
            {
                entity.HasKey(e => e.IdModulos);

                entity.ToTable("modulos", "diogo");

                entity.Property(e => e.IdModulos)
                    .HasColumnName("ID_Modulos")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Endpoint)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PerfilUtilizador>(entity =>
            {
                entity.HasKey(e => e.IdPerfilUtilizador);

                entity.ToTable("perfil_utilizador", "diogo");

                entity.Property(e => e.IdPerfilUtilizador)
                    .HasColumnName("ID_Perfil_Utilizador")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permissoes>(entity =>
            {
                entity.HasKey(e => e.IdPermissao);

                entity.ToTable("permissoes", "diogo");

                entity.HasIndex(e => e.IdModulo)
                    .HasName("ID_Modulo");

                entity.HasIndex(e => e.IdPerfilUtilizador)
                    .HasName("ID_Perfil_Utilizador");

                entity.Property(e => e.IdPermissao)
                    .HasColumnName("ID_Permissao")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Criar)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Eliminar)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Escrever)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdModulo)
                    .HasColumnName("ID_Modulo")
                    .HasColumnType("int(10)");

                entity.Property(e => e.IdPerfilUtilizador)
                    .HasColumnName("ID_Perfil_Utilizador")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Ler)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Permissoes)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("permissoes_ibfk_2");

                entity.HasOne(d => d.IdPerfilUtilizadorNavigation)
                    .WithMany(p => p.Permissoes)
                    .HasForeignKey(d => d.IdPerfilUtilizador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("permissoes_ibfk_1");
            });

            modelBuilder.Entity<ProfissionaisDeSaude>(entity =>
            {
                entity.HasKey(e => e.IdProfissional);

                entity.ToTable("profissionais_de_saude", "diogo");

                entity.HasIndex(e => e.IdHospital)
                    .HasName("ID_Hospital");

                entity.HasIndex(e => e.IdUtilizador)
                    .HasName("ID_Utilizador");

                entity.Property(e => e.IdProfissional)
                    .HasColumnName("ID_Profissional")
                    .HasColumnType("int(10)");

                entity.Property(e => e.IdHospital)
                    .HasColumnName("ID_Hospital")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.IdUtilizador)
                    .HasColumnName("ID_Utilizador")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Profissao)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdHospitalNavigation)
                    .WithMany(p => p.ProfissionaisDeSaude)
                    .HasForeignKey(d => d.IdHospital)
                    .HasConstraintName("profissionais_de_saude_ibfk_2");

                entity.HasOne(d => d.IdUtilizadorNavigation)
                    .WithMany(p => p.ProfissionaisDeSaude)
                    .HasForeignKey(d => d.IdUtilizador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("profissionais_de_saude_ibfk_1");
            });

            modelBuilder.Entity<Teste>(entity =>
            {
                entity.HasKey(e => e.IdTeste);

                entity.ToTable("teste", "diogo");

                entity.HasIndex(e => e.IdDoente)
                    .HasName("ID_Doente");

                entity.HasIndex(e => e.IdProfissional)
                    .HasName("ID_Profissional");

                entity.Property(e => e.IdTeste)
                    .HasColumnName("ID_Teste")
                    .HasColumnType("int(10)");

                entity.Property(e => e.DataTeste)
                    .HasColumnName("Data_Teste")
                    .HasColumnType("date");

                entity.Property(e => e.IdDoente)
                    .HasColumnName("ID_Doente")
                    .HasColumnType("int(10)");

                entity.Property(e => e.IdProfissional)
                    .HasColumnName("ID_Profissional")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ResultadoTeste)
                    .IsRequired()
                    .HasColumnName("Resultado_Teste")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoTeste)
                    .IsRequired()
                    .HasColumnName("Tipo_Teste")
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDoenteNavigation)
                    .WithMany(p => p.Teste)
                    .HasForeignKey(d => d.IdDoente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("teste_ibfk_1");

                entity.HasOne(d => d.IdProfissionalNavigation)
                    .WithMany(p => p.Teste)
                    .HasForeignKey(d => d.IdProfissional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("teste_ibfk_2");
            });

            modelBuilder.Entity<Utilizador>(entity =>
            {
                entity.HasKey(e => e.IdUtilizador);

                entity.ToTable("utilizador", "diogo");

                entity.HasIndex(e => e.IdPerfilUtilizador)
                    .HasName("ID_Perfil_Utilizador");

                entity.Property(e => e.IdUtilizador)
                    .HasColumnName("ID_Utilizador")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Cc)
                    .HasColumnName("CC")
                    .HasColumnType("int(10)");

                entity.Property(e => e.IdPerfilUtilizador)
                    .HasColumnName("ID_Perfil_Utilizador")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idade).HasColumnType("int(5)");

                entity.Property(e => e.Morada)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nib)
                    .HasColumnName("NIB")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo).HasColumnType("int(5)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPerfilUtilizadorNavigation)
                    .WithMany(p => p.Utilizador)
                    .HasForeignKey(d => d.IdPerfilUtilizador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("utilizador_ibfk_1");
            });
        }
    }
}
