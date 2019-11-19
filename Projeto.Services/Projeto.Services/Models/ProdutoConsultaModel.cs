﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.Models
{
    public class ProdutoConsultaModel
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }
    }
}
