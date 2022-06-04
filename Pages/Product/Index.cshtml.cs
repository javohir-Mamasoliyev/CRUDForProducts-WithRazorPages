using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUDForProducts.Data;
using CRUDForProducts.Model;

namespace CRUDForProducts.Pages.Product
{
#pragma warning disable
    public class IndexModel : PageModel
    {
        private readonly CRUDForProducts.Data.CRUDForProductsContext _context;

        public IndexModel(CRUDForProducts.Data.CRUDForProductsContext context)
        {
            _context = context;
        }

        public IList<ProductCollections> ProductCollections { get;set; } = default!;

        public async Task OnGetAsync(string SearchString)
        {
            var products = from a in _context.ProductCollections
                           select a;

            if (!String.IsNullOrEmpty(SearchString))
            {
                products = _context.ProductCollections.Where(x => x.Name!.Contains(SearchString));
            }


            if (_context.ProductCollections != null)
            {
                ProductCollections = await products.ToListAsync();
            }
        }
    }
}
