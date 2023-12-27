using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityLinq.Repository.Models
{
    [Table("Cliente")]
    [Index(nameof(SuporteId), Name = "IFK_ClienteSuporteId")]
    public partial class Cliente
    {
        public Cliente()
        {
            NotaFiscals = new HashSet<NotaFiscal>();
        }

        [Key]
        public int ClienteId { get; set; }
        [Required]
        [StringLength(40)]
        public string PrimeiroNome { get; set; }
        [Required]
        [StringLength(20)]
        public string Sobrenome { get; set; }
        [StringLength(80)]
        public string Empresa { get; set; }
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
        [StringLength(24)]
        public string Fone { get; set; }
        [StringLength(24)]
        public string Fax { get; set; }
        [Required]
        [StringLength(60)]
        public string Email { get; set; }
        public int? SuporteId { get; set; }

        [ForeignKey(nameof(SuporteId))]
        [InverseProperty(nameof(Funcionario.Clientes))]
        public virtual Funcionario Suporte { get; set; }
        [InverseProperty(nameof(NotaFiscal.Cliente))]
        public virtual ICollection<NotaFiscal> NotaFiscals { get; set; }
    }
}
