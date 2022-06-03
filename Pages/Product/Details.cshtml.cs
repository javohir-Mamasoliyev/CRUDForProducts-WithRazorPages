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
    public class DetailsModel : PageModel
    {
        private readonly CRUDForProducts.Data.CRUDForProductsContext _context;

        public DetailsModel(CRUDForProducts.Data.CRUDForProductsContext context)
        {
            _context = context;
        }

      public ProductCollections ProductCollections { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductCollections == null)
            {
                return NotFound();
            }

            var productcollections = await _context.ProductCollections.FirstOrDefaultAsync(m => m.Id == id);
            if (productcollections == null)
            {
                return NotFound();
            }
            else 
            {
                ProductCollections = productcollections;
            }
            return Page();
        }
    }
}
