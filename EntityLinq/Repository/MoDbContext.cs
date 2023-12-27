using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EntityLinq.Repository.Models;

#nullable disable

namespace EntityLinq.Repository
{
    public partial class MoDbContext : DbContext
    {
        public MoDbContext()
        {
        }

        public MoDbContext(DbContextOptions<MoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artistum> Artista { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Faixa> Faixas { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<ItemNotaFiscal> ItemNotaFiscals { get; set; }
        public virtual DbSet<NotaFiscal> NotaFiscals { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistFaixa> PlaylistFaixas { get; set; }
        public virtual DbSet<TipoMidium> TipoMidia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Rafael\\source\\repos\\EntityLinq\\EntityLinq\\Data\\AluraTunes.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasOne(d => d.Artista)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumArtistaId");
            });

            modelBuilder.Entity<Artistum>(entity =>
            {
                entity.HasKey(e => e.ArtistaId)
                    .HasName("PK_Artist");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasOne(d => d.Suporte)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.SuporteId)
                    .HasConstraintName("FK_ClienteSuporteId");
            });

            modelBuilder.Entity<Faixa>(entity =>
            {
                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Faixas)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK_FaixaAlbumId");

                entity.HasOne(d => d.Genero)
                    .WithMany(p => p.Faixas)
                    .HasForeignKey(d => d.GeneroId)
                    .HasConstraintName("FK_FaixaGeneroId");

                entity.HasOne(d => d.TipoMidia)
                    .WithMany(p => p.Faixas)
                    .HasForeignKey(d => d.TipoMidiaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaixaTipoMidiaId");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasOne(d => d.SeReportaANavigation)
                    .WithMany(p => p.InverseSeReportaANavigation)
                    .HasForeignKey(d => d.SeReportaA)
                    .HasConstraintName("FK_FuncionarioSeReportaA");
            });

            modelBuilder.Entity<ItemNotaFiscal>(entity =>
            {
                entity.HasOne(d => d.Faixa)
                    .WithMany(p => p.ItemNotaFiscals)
                    .HasForeignKey(d => d.FaixaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemNotaFiscalFaixaId");

                entity.HasOne(d => d.NotaFiscal)
                    .WithMany(p => p.ItemNotaFiscals)
                    .HasForeignKey(d => d.NotaFiscalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemNotaFiscalNotaFiscalId");
            });

            modelBuilder.Entity<NotaFiscal>(entity =>
            {
                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.NotaFiscals)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotaFiscalClienteId");
            });

            modelBuilder.Entity<PlaylistFaixa>(entity =>
            {
                entity.HasKey(e => new { e.PlaylistId, e.FaixaId })
                    .IsClustered(false);

                entity.HasOne(d => d.Faixa)
                    .WithMany(p => p.PlaylistFaixas)
                    .HasForeignKey(d => d.FaixaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistFaixaFaixaId");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.PlaylistFaixas)
                    .HasForeignKey(d => d.PlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistFaixaPlaylistId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
