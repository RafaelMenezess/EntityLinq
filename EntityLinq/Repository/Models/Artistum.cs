using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityLinq.Repository.Models
{
    public partial class Artistum
    {
        public Artistum()
        {
            Albums = new HashSet<Album>();
        }

        [Key]
        public int ArtistaId { get; set; }
        [StringLength(120)]
        public string Nome { get; set; }

        [InverseProperty(nameof(Album.Artista))]
        public virtual ICollection<Album> Albums { get; set; }
    }
}
