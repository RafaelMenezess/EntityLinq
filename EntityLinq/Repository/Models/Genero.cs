using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityLinq.Repository.Models
{
    [Table("Genero")]
    public partial class Genero
    {
        public Genero()
        {
            Faixas = new HashSet<Faixa>();
        }

        [Key]
        public int GeneroId { get; set; }
        [StringLength(120)]
        public string Nome { get; set; }

        [InverseProperty(nameof(Faixa.Genero))]
        public virtual ICollection<Faixa> Faixas { get; set; }
    }
}
