using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAutoGlass.Dtos
{
    public class ProdutoDto
    {
        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; } 
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int IdFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }
    }
}
