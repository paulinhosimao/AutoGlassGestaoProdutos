using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteAutoGlass.Models;

namespace TesteAutoGlass.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Produtos> Produto { get; set; }
        public DbSet<Fornecedores> Fornecedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Produtos>().ToTable("Produtos");
            modelBuilder.Entity<Fornecedores>().ToTable("Fornecedors");

           

            modelBuilder.Entity<Produtos>()
                .HasKey(f => f.IdProduto);

            modelBuilder.Entity<Fornecedores>()
               .HasKey(f => f.IdFornecedor);

            base.OnModelCreating(modelBuilder);
        }



    }
}


