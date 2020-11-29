using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using APIPix4Fun.Domains;

namespace APIPix4Fun.Context
{
    public partial class Pix4FunContext : DbContext
    {
        public Pix4FunContext()
        {
        }

        public Pix4FunContext(DbContextOptions<Pix4FunContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cupom> Cupons { get; set; }
        public virtual DbSet<Foto> Fotos { get; set; }
        public virtual DbSet<Pack> Packs { get; set; }
        public virtual DbSet<Pagamento> Pagamentos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Perfilacesso> Perfilacesso { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=127.0.0.1;database=PixFourFun;uid=root;pwd=251220011qazZ", x => x.ServerVersion("8.0.22-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cupom>(entity =>
            {
                entity.HasKey(e => e.IdCupom)
                    .HasName("PRIMARY");

                entity.ToTable("cupom");

                entity.Property(e => e.DataValidade).HasColumnType("datetime");

                entity.Property(e => e.PalavraChave)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Foto>(entity =>
            {
                entity.HasKey(e => e.IdFoto)
                    .HasName("PRIMARY");

                entity.ToTable("foto");

                entity.Property(e => e.FraseFoto)
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UrlImagem)
                    .HasColumnType("varchar(512)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Pack>(entity =>
            {
                entity.HasKey(e => e.IdPack)
                    .HasName("PRIMARY");

                entity.ToTable("pack");

                entity.HasIndex(e => e.IdFoto)
                    .HasName("IdFoto");

                entity.Property(e => e.TipoPack)
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdFotoNavigation)
                    .WithMany(p => p.Pack)
                    .HasForeignKey(d => d.IdFoto)
                    .HasConstraintName("pack_ibfk_1");
            });

            modelBuilder.Entity<Pagamento>(entity =>
            {
                entity.HasKey(e => e.IdPagamento)
                    .HasName("PRIMARY");

                entity.ToTable("pagamento");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("IdUsuario");

                entity.Property(e => e.StatusPgto)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TipoEnvio)
                    .HasColumnType("varchar(80)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TipoPgto)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pagamento)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("pagamento_ibfk_1");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PRIMARY");

                entity.ToTable("pedido");

                entity.HasIndex(e => e.IdCupom)
                    .HasName("IdCupom");

                entity.HasIndex(e => e.IdPack)
                    .HasName("IdPack");

                entity.HasIndex(e => e.IdPagamento)
                    .HasName("IdPagamento");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("IdUsuario");

                entity.Property(e => e.StatusPedido)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdCupomNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdCupom)
                    .HasConstraintName("pedido_ibfk_3");

                entity.HasOne(d => d.IdPackNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdPack)
                    .HasConstraintName("pedido_ibfk_2");

                entity.HasOne(d => d.IdPagamentoNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdPagamento)
                    .HasConstraintName("pedido_ibfk_4");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("pedido_ibfk_1");
            });

            modelBuilder.Entity<Perfilacesso>(entity =>
            {
                entity.HasKey(e => e.IdPerfilAcesso)
                    .HasName("PRIMARY");

                entity.ToTable("perfilacesso");

                entity.Property(e => e.TipoPerfil)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.IdPerfilAcesso)
                    .HasName("IdPerfilAcesso");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nome)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Senha)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Telefone)
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdPerfilAcessoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPerfilAcesso)
                    .HasConstraintName("usuario_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
