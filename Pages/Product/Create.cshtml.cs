using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUDForProducts.Data;
using CRUDForProducts.Model;

namespace CRUDForProducts.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly CRUDForProducts.Data.CRUDForProductsContext _context;

        public CreateModel(CRUDForProducts.Data.CRUDForProductsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProductCollections ProductCollections { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ProductCollections == null || ProductCollections == null)
            {
                return Page();
            }

            _context.ProductCollections.Add(ProductCollections);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
