using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityLinq.Repository.Models
{
    public partial class TipoMidium
    {
        public TipoMidium()
        {
            Faixas = new HashSet<Faixa>();
        }

        [Key]
        public int TipoMidiaId { get; set; }
        [StringLength(120)]
        public string Nome { get; set; }

        [InverseProperty(nameof(Faixa.TipoMidia))]
        public virtual ICollection<Faixa> Faixas { get; set; }
    }
}
