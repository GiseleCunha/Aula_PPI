using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aula10_relacionamento1toN.Models
{
    public class Afiliado
    {
        private ICollection<Dependente> Meusdependentes;
        private long id;
        private string nome;

        [Key]
        [Display(Name ="Número do Titulo")]
        public long Id { get => id; set => id = value; }
        [Display(Name ="Nome do Afiliado")]
        [MaxLength(30,ErrorMessage ="Permite até 30 caracteres")]
        [Required(ErrorMessage ="Preecha o campo {0}")]
        public string Nome { get => nome; set => nome = value; }
        public ICollection<Dependente> Meusdependentes1 { get => Meusdependentes; set => Meusdependentes = value; }
    }
}
