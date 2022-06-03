using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUDForProducts.Model;

namespace CRUDForProducts.Data
{
    public class CRUDForProductsContext : DbContext
    {
        public CRUDForProductsContext (DbContextOptions<CRUDForProductsContext> options)
            : base(options)
        {
        }

        public DbSet<CRUDForProducts.Model.ProductCollections>? ProductCollections { get; set; }
    }
}
