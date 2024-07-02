using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAutoGlass.Models
{
    public class Produtos
    {

        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; } = "Ativo";
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int IdFornecedor { get; set; }
        public Fornecedores fornecedores { get; set; }

        public Produtos() { } // Construtor padrão
    }
}
