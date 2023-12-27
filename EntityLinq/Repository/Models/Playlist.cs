using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityLinq.Repository.Models
{
    [Table("Playlist")]
    public partial class Playlist
    {
        public Playlist()
        {
            PlaylistFaixas = new HashSet<PlaylistFaixa>();
        }

        [Key]
        public int PlaylistId { get; set; }
        [StringLength(120)]
        public string Nome { get; set; }

        [InverseProperty(nameof(PlaylistFaixa.Playlist))]
        public virtual ICollection<PlaylistFaixa> PlaylistFaixas { get; set; }
    }
}
