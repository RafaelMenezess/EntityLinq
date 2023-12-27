using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityLinq.Repository.Models
{
    [Table("Faixa")]
    [Index(nameof(AlbumId), Name = "IFK_FaixaAlbumId")]
    [Index(nameof(GeneroId), Name = "IFK_FaixaGeneroId")]
    [Index(nameof(TipoMidiaId), Name = "IFK_FaixaTipoMidiaId")]
    public partial class Faixa
    {
        public Faixa()
        {
            ItemNotaFiscals = new HashSet<ItemNotaFiscal>();
            PlaylistFaixas = new HashSet<PlaylistFaixa>();
        }

        [Key]
        public int FaixaId { get; set; }
        [Required]
        [StringLength(200)]
        public string Nome { get; set; }
        public int? AlbumId { get; set; }
        public int TipoMidiaId { get; set; }
        public int? GeneroId { get; set; }
        [StringLength(220)]
        public string Compositor { get; set; }
        public int Milissegundos { get; set; }
        public int? Bytes { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal PrecoUnitario { get; set; }

        [ForeignKey(nameof(AlbumId))]
        [InverseProperty("Faixas")]
        public virtual Album Album { get; set; }
        [ForeignKey(nameof(GeneroId))]
        [InverseProperty("Faixas")]
        public virtual Genero Genero { get; set; }
        [ForeignKey(nameof(TipoMidiaId))]
        [InverseProperty(nameof(TipoMidium.Faixas))]
        public virtual TipoMidium TipoMidia { get; set; }
        [InverseProperty(nameof(ItemNotaFiscal.Faixa))]
        public virtual ICollection<ItemNotaFiscal> ItemNotaFiscals { get; set; }
        [InverseProperty(nameof(PlaylistFaixa.Faixa))]
        public virtual ICollection<PlaylistFaixa> PlaylistFaixas { get; set; }
    }
}
