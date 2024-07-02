using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAutoGlass.Models
{
    public class Fornecedores
    {
       
        public int IdFornecedor { get; set; }
        public string Descricao { get; set; }
        public string CNPJ { get; set; }

        public Fornecedores() { } // Construtor padrão
    }
}
