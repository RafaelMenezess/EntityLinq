using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityLinq.Repository.Models
{
    [Table("PlaylistFaixa")]
    [Index(nameof(FaixaId), Name = "IFK_PlaylistFaixaFaixaId")]
    public partial class PlaylistFaixa
    {
        [Key]
        public int PlaylistId { get; set; }
        [Key]
        public int FaixaId { get; set; }

        [ForeignKey(nameof(FaixaId))]
        [InverseProperty("PlaylistFaixas")]
        public virtual Faixa Faixa { get; set; }
        [ForeignKey(nameof(PlaylistId))]
        [InverseProperty("PlaylistFaixas")]
        public virtual Playlist Playlist { get; set; }
    }
}
