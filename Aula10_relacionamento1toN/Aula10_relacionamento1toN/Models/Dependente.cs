using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aula10_relacionamento1toN.Models
{
    public class Dependente
    {
        private long id;
        private string nome;
        private Afiliado responsavel;
        private long responsavelId;

        [Key]
        [Display(Name ="Número identificador")]
        public long Id { get => id; set => id = value; }

        [Display(Name = "Nome do Dependente")]
        [MaxLength(30, ErrorMessage = "Permite até 30 caracteres")]
        [Required(ErrorMessage = "Preecha o campo {0}")]
        public string Nome { get => nome; set => nome = value; }
        public Afiliado Responsavel { get => responsavel; set => responsavel = value; }
        public long ResponsavelId { get => responsavelId; set => responsavelId = value; }
    }
}
