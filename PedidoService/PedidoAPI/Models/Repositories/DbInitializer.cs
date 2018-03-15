using System.Linq;
using System.Collections.Generic;

namespace PedidoAPI.Models.Repositories
{
    public static class DbInitializer
    {

        public static void Initialize(GenericDbContext context)
        {

            context.Database.EnsureCreated();           
        }
    }
}