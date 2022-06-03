using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDForProducts.Data;
using CRUDForProducts.Model;

namespace CRUDForProducts.Pages.Product
{
    public class EditModel : PageModel
    {
        private readonly CRUDForProducts.Data.CRUDForProductsContext _context;

        public EditModel(CRUDForProducts.Data.CRUDForProductsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductCollections ProductCollections { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductCollections == null)
            {
                return NotFound();
            }

            var productcollections =  await _context.ProductCollections.FirstOrDefaultAsync(m => m.Id == id);
            if (productcollections == null)
            {
                return NotFound();
            }
            ProductCollections = productcollections;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProductCollections).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCollectionsExists(ProductCollections.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductCollectionsExists(int id)
        {
          return (_context.ProductCollections?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
