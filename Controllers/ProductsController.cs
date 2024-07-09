using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyECommerceApp.Data; // Replace with the actual namespace of your Data folder
using MyECommerceApp.Models; // Replace with the actual namespace of your Models folder
using System.Threading.Tasks;

public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> ProductsIndex()
    {
        return View(await _context.Products.ToListAsync());
    }

    public async Task<IActionResult> Description(int? id) 
    {
        if(id == null) {
            var errorViewModel = new ErrorViewModel {
                ErrorMessage = "Product does not have a description."
            };
        
        return View("Error", errorViewModel);
        }

        var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);
        if (product == null) 
        {
            var errorViewModel = new ErrorViewModel 
            {
                ErrorMessage = "Product not found."
            };
            return View("Error", errorViewModel);
        }
        return View(product);
    }
    // Other actions
}
