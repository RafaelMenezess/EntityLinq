using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityLinq.Repository.Models
{
    [Table("ItemNotaFiscal")]
    [Index(nameof(FaixaId), Name = "IFK_ItemNotaFiscalFaixaId")]
    [Index(nameof(NotaFiscalId), Name = "IFK_ItemNotaFiscalNotaFiscalId")]
    public partial class ItemNotaFiscal
    {
        [Key]
        public int ItemNotaFiscalId { get; set; }
        public int NotaFiscalId { get; set; }
        public int FaixaId { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }

        [ForeignKey(nameof(FaixaId))]
        [InverseProperty("ItemNotaFiscals")]
        public virtual Faixa Faixa { get; set; }
        [ForeignKey(nameof(NotaFiscalId))]
        [InverseProperty("ItemNotaFiscals")]
        public virtual NotaFiscal NotaFiscal { get; set; }
    }
}
