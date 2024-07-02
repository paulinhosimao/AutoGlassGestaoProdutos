using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteAutoGlass.Models;

namespace TesteAutoGlass.Services
{
    public interface IProdutosService
    {
        Task<Produtos> GetProdutoByIdAsync(int id);
        Task<IEnumerable<Produtos>> GetProdutosAsync();
        Task<IEnumerable<Produtos>> GetProdutosFiltroAsync(string filter, int pageNumber, int pageSize);
        Task AddProdutoAsync(Produtos produto);
        Task UpdateProdutoAsync(Produtos produto);
        Task DeleteProdutoAsync(int id);
    }
}
