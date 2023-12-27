using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityLinq.Repository.Models
{
    [Table("Album")]
    [Index(nameof(ArtistaId), Name = "IFK_AlbumArtistaId")]
    public partial class Album
    {
        public Album()
        {
            Faixas = new HashSet<Faixa>();
        }

        [Key]
        public int AlbumId { get; set; }
        [Required]
        [StringLength(160)]
        public string Titulo { get; set; }
        public int ArtistaId { get; set; }

        [ForeignKey(nameof(ArtistaId))]
        [InverseProperty(nameof(Artistum.Albums))]
        public virtual Artistum Artista { get; set; }
        [InverseProperty(nameof(Faixa.Album))]
        public virtual ICollection<Faixa> Faixas { get; set; }
    }
}
