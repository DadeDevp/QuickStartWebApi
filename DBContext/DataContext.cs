using Microsoft.EntityFrameworkCore;
using QuickStartWebApi.Models;
using System.Collections.Generic;

namespace QuickStartWebApi.DBContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
