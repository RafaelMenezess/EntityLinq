using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityLinq.Repository.Models
{
    [Table("NotaFiscal")]
    [Index(nameof(ClienteId), Name = "IFK_NotaFiscalClienteId")]
    public partial class NotaFiscal
    {
        public NotaFiscal()
        {
            ItemNotaFiscals = new HashSet<ItemNotaFiscal>();
        }

        [Key]
        public int NotaFiscalId { get; set; }
        public int ClienteId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataNotaFiscal { get; set; }
        [StringLength(70)]
        public string Endereco { get; set; }
        [StringLength(40)]
        public string Cidade { get; set; }
        [StringLength(40)]
        public string Estado { get; set; }
        [StringLength(40)]
        public string Pais { get; set; }
        [Column("CEP")]
        [StringLength(10)]
        public string Cep { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal Total { get; set; }

        [ForeignKey(nameof(ClienteId))]
        [InverseProperty("NotaFiscals")]
        public virtual Cliente Cliente { get; set; }
        [InverseProperty(nameof(ItemNotaFiscal.NotaFiscal))]
        public virtual ICollection<ItemNotaFiscal> ItemNotaFiscals { get; set; }
    }
}
