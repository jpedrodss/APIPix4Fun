﻿// <auto-generated />
using System;
using APIPix4Fun.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIPix4Fun.Migrations
{
    [DbContext(typeof(Pix4FunContext))]
    [Migration("20201209133314_AlterTableUsuario")]
    partial class AlterTableUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("APIPix4Fun.Domains.Cupom", b =>
                {
                    b.Property<int>("IdCupom")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataValidade")
                        .HasColumnType("datetime");

                    b.Property<string>("PalavraChave")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<float?>("ValorDesconto")
                        .HasColumnType("float");

                    b.HasKey("IdCupom")
                        .HasName("PRIMARY");

                    b.ToTable("cupom");
                });

            modelBuilder.Entity("APIPix4Fun.Domains.Endereco", b =>
                {
                    b.Property<int>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnName("CEP")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnName("UF")
                        .HasColumnType("varchar(2)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.HasKey("IdEndereco")
                        .HasName("PRIMARY");

                    b.HasIndex("IdUsuario")
                        .HasName("IdUsuario");

                    b.ToTable("endereco");
                });

            modelBuilder.Entity("APIPix4Fun.Domains.Foto", b =>
                {
                    b.Property<int>("IdFoto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FraseFoto")
                        .HasColumnType("varchar(60)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("UrlImagem")
                        .HasColumnType("varchar(512)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.HasKey("IdFoto")
                        .HasName("PRIMARY");

                    b.ToTable("foto");
                });

            modelBuilder.Entity("APIPix4Fun.Domains.Pack", b =>
                {
                    b.Property<int>("IdPack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("IdFoto")
                        .HasColumnType("int");

                    b.Property<float?>("Preco")
                        .HasColumnType("float");

                    b.Property<string>("TipoPack")
                        .HasColumnType("varchar(15)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.HasKey("IdPack")
                        .HasName("PRIMARY");

                    b.HasIndex("IdFoto")
                        .HasName("IdFoto");

                    b.ToTable("pack");
                });

            modelBuilder.Entity("APIPix4Fun.Domains.Pagamento", b =>
                {
                    b.Property<int>("IdPagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("StatusPgto")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("TipoEnvio")
                        .HasColumnType("varchar(80)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("TipoPgto")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<float?>("ValorTotal")
                        .HasColumnType("float");

                    b.HasKey("IdPagamento")
                        .HasName("PRIMARY");

                    b.HasIndex("IdUsuario")
                        .HasName("IdUsuario");

                    b.ToTable("pagamento");
                });

            modelBuilder.Entity("APIPix4Fun.Domains.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("IdCupom")
                        .HasColumnType("int");

                    b.Property<int?>("IdPack")
                        .HasColumnType("int");

                    b.Property<int?>("IdPagamento")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("StatusPedido")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.HasKey("IdPedido")
                        .HasName("PRIMARY");

                    b.HasIndex("IdCupom")
                        .HasName("IdCupom");

                    b.HasIndex("IdPack")
                        .HasName("IdPack");

                    b.HasIndex("IdPagamento")
                        .HasName("IdPagamento");

                    b.HasIndex("IdUsuario")
                        .HasName("IdUsuario");

                    b.ToTable("pedido");
                });

            modelBuilder.Entity("APIPix4Fun.Domains.Perfilacesso", b =>
                {
                    b.Property<int>("IdPerfilAcesso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TipoPerfil")
                        .HasColumnType("varchar(20)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.HasKey("IdPerfilAcesso")
                        .HasName("PRIMARY");

                    b.ToTable("perfilacesso");
                });

            modelBuilder.Entity("APIPix4Fun.Domains.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(40)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<int?>("IdPerfilAcesso")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Numero")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Rua")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Senha")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(30)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.HasKey("IdUsuario")
                        .HasName("PRIMARY");

                    b.HasIndex("IdPerfilAcesso")
                        .HasName("IdPerfilAcesso");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("APIPix4Fun.Domains.Endereco", b =>
                {
                    b.HasOne("APIPix4Fun.Domains.Usuario", "IdUsuarioNavigation")
                        .WithMany("Endereco")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("endereco_ibfk_1");
                });

            modelBuilder.Entity("APIPix4Fun.Domains.Pack", b =>
                {
                    b.HasOne("APIPix4Fun.Domains.Foto", "IdFotoNavigation")
                        .WithMany("Pack")
                        .HasForeignKey("IdFoto")
                        .HasConstraintName("pack_ibfk_1");
                });

            modelBuilder.Entity("APIPix4Fun.Domains.Pagamento", b =>
                {
                    b.HasOne("APIPix4Fun.Domains.Usuario", "IdUsuarioNavigation")
                        .WithMany("Pagamento")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("pagamento_ibfk_1");
                });

            modelBuilder.Entity("APIPix4Fun.Domains.Pedido", b =>
                {
                    b.HasOne("APIPix4Fun.Domains.Cupom", "IdCupomNavigation")
                        .WithMany("Pedido")
                        .HasForeignKey("IdCupom")
                        .HasConstraintName("pedido_ibfk_3");

                    b.HasOne("APIPix4Fun.Domains.Pack", "IdPackNavigation")
                        .WithMany("Pedido")
                        .HasForeignKey("IdPack")
                        .HasConstraintName("pedido_ibfk_2");

                    b.HasOne("APIPix4Fun.Domains.Pagamento", "IdPagamentoNavigation")
                        .WithMany("Pedido")
                        .HasForeignKey("IdPagamento")
                        .HasConstraintName("pedido_ibfk_4");

                    b.HasOne("APIPix4Fun.Domains.Usuario", "IdUsuarioNavigation")
                        .WithMany("Pedido")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("pedido_ibfk_1");
                });

            modelBuilder.Entity("APIPix4Fun.Domains.Usuario", b =>
                {
                    b.HasOne("APIPix4Fun.Domains.Perfilacesso", "IdPerfilAcessoNavigation")
                        .WithMany("Usuario")
                        .HasForeignKey("IdPerfilAcesso")
                        .HasConstraintName("usuario_ibfk_1");
                });
#pragma warning restore 612, 618
        }
    }
}
