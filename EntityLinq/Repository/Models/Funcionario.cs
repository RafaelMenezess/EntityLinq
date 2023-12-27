using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityLinq.Repository.Models
{
    [Table("Funcionario")]
    [Index(nameof(SeReportaA), Name = "IFK_FuncionarioSeReportaA")]
    public partial class Funcionario
    {
        public Funcionario()
        {
            Clientes = new HashSet<Cliente>();
            InverseSeReportaANavigation = new HashSet<Funcionario>();
        }

        [Key]
        public int FuncionarioId { get; set; }
        [Required]
        [StringLength(20)]
        public string Sobrenome { get; set; }
        [Required]
        [StringLength(20)]
        public string PrimeiroNome { get; set; }
        [StringLength(30)]
        public string Titulo { get; set; }
        public int? SeReportaA { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataNascimento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAdmissao { get; set; }
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
        [StringLength(60)]
        public string Email { get; set; }

        [ForeignKey(nameof(SeReportaA))]
        [InverseProperty(nameof(Funcionario.InverseSeReportaANavigation))]
        public virtual Funcionario SeReportaANavigation { get; set; }
        [InverseProperty(nameof(Cliente.Suporte))]
        public virtual ICollection<Cliente> Clientes { get; set; }
        [InverseProperty(nameof(Funcionario.SeReportaANavigation))]
        public virtual ICollection<Funcionario> InverseSeReportaANavigation { get; set; }
    }
}
