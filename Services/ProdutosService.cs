using System;
using Microsoft.EntityFrameworkCore;
using TesteAutoGlass.Data;
using TesteAutoGlass.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace TesteAutoGlass.Services
{
    public class ProdutosService : IProdutosService
    {
        private readonly AppDbContext _context;
        public ProdutosService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produtos> GetProdutoByIdAsync(int id)
        {
            return await _context.Produto.FindAsync(id);
        }

        public async Task<IEnumerable<Produtos>> GetProdutosAsync()
        {
            return await _context.Produto.ToListAsync();
        }

        public async Task<IEnumerable<Produtos>> GetProdutosFiltroAsync(string filter, int pageNumber, int pageSize)
        {
            return await _context.Produto
                .Where(p => p.Descricao.Contains(filter))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task AddProdutoAsync(Produtos produto)
        {
            if (produto.DataFabricacao >= produto.DataValidade)
            {
                throw new ArgumentException("Data de fabricação não pode ser maior ou igual à data de validade.");
            }
            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProdutoAsync(Produtos produto)
        {
            if (produto.DataFabricacao >= produto.DataValidade)
            {
                throw new ArgumentException("Data de fabricação não pode ser maior ou igual à data de validade.");
            }
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProdutoAsync(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            if (produto != null)
            {
                produto.Status = "Inativo";
                await _context.SaveChangesAsync();
            }
        }
    }
}
