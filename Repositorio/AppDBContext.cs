using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entidades;


namespace Repositorio
{
    public class AppDBContext : DbContext
    {
        string conexao = @"Server=sql5108.site4now.net;Database=db_a7a5bf_dbvestuario2021;User Id=db_a7a5bf_dbvestuario2021_admin;password=12345678Ma@;MultipleActiveResultSets=true";
        //Trusted_Connection=True;


        public AppDBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conexao);
        }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Produto> produtos { get; set; }
        public DbSet<produtoGenero> generos { get; set; }
        public DbSet<produtoMarca> marcas { get; set; }
        public DbSet<produtoTamanho> tamanhos { get; set; }
        public DbSet<produtoCategoria> categorias { get; set; }
        public DbSet<Imagens> imagens { get; set; }
        public DbSet<produtoStatus> produtoStatus{ get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<usuarioEndereco> usuarioEndereco{ get; set; }
        public DbSet<usuarioTipo> usuarioTipo{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Produto
            modelBuilder.Entity<Produto>().
                Property(p => p.prod_Descricao).HasMaxLength(150);
            modelBuilder.Entity<Produto>().
                Property(p => p.prod_preco).HasPrecision(18, 2);
            modelBuilder.Entity<Produto>().
                Property(p => p.prod_dataCadastro).HasPrecision(6);
            #endregion
            #region produtoCategoria
            modelBuilder.Entity<produtoCategoria>().
                Property(p => p.cat_descricao).HasMaxLength(30);
            modelBuilder.Entity<produtoGenero>().
                Property(p => p.genero_desc).HasMaxLength(10);
            modelBuilder.Entity<produtoMarca>().
                Property(p => p.marca_desc).HasMaxLength(30);
            modelBuilder.Entity<produtoStatus>().
                Property(p => p.status_desc).HasMaxLength(20);
            modelBuilder.Entity<produtoTamanho>().
                Property(p => p.tamanho_desc).HasMaxLength(3);
            #endregion
            #region Usuario
            modelBuilder.Entity<Usuario>().
            Property(p => p.usu_nome).HasMaxLength(150);

            modelBuilder.Entity<Usuario>().
                Property(p => p.usu_cpf).HasMaxLength(14);

            modelBuilder.Entity<Usuario>().
                Property(p => p.usu_dataCriacao).HasPrecision(6);

            modelBuilder.Entity<Usuario>().
                Property(p => p.usu_email).HasMaxLength(50);

            modelBuilder.Entity<Usuario>().
                Property(p => p.usu_senha).HasMaxLength(20);
            #endregion
            #region usuarioEndereco
            modelBuilder.Entity<usuarioEndereco>().
                Property(p => p.end_descricao).HasMaxLength(60);
            modelBuilder.Entity<usuarioEndereco>().
                Property(p => p.end_endereco).HasMaxLength(60);
            modelBuilder.Entity<usuarioEndereco>().
                Property(p => p.end_bairro).HasMaxLength(30);
            modelBuilder.Entity<usuarioEndereco>().
                Property(p => p.end_cidade).HasMaxLength(40);
            modelBuilder.Entity<usuarioEndereco>().
                Property(p => p.end_estado).HasMaxLength(40);
            modelBuilder.Entity<usuarioEndereco>().
                Property(p => p.end_CEP).HasMaxLength(9);
            modelBuilder.Entity<usuarioEndereco>().
                Property(p => p.end_referencia).HasMaxLength(40);
            modelBuilder.Entity<usuarioEndereco>().
                Property(p => p.end_numero).HasMaxLength(10);
            modelBuilder.Entity<usuarioEndereco>().
                Property(p => p.end_referencia).HasMaxLength(40);
            #endregion
            #region usuarioTipo
            modelBuilder.Entity<usuarioTipo>().
                Property(p => p.usuarioTipo_desc).HasMaxLength(20);
            #endregion
        }
    }
}
