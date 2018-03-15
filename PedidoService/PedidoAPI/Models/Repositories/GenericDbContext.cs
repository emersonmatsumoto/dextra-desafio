using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PedidoAPI.Models.Repositories
{
    public class GenericDbContext : DbContext
    {
        private static bool _created = false;
        public GenericDbContext(DbContextOptions<GenericDbContext> options)
        : base(options)
        {
            if (!_created)
            {
                Database.EnsureCreated();
                _created = true;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PedidoMap(modelBuilder.Entity<Pedido>());
            new ItemMap(modelBuilder.Entity<Item>());
            new DescontoMap(modelBuilder.Entity<Desconto>());
        }

    }
}