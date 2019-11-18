using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.Models
{
    public class ProdutoCadastroModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public int Quantidade { get; set; }
    }
}
