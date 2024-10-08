using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyECommerceApp.Data; // Replace with the actual namespace of your Data folder
using MyECommerceApp.Models; // Replace with the actual namespace of your Models folder
using System.Security.Claims;
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
    [HttpPost]
    public async Task<IActionResult> AddToCart(int productId, int quantity)
    {
        var userId = GetCurrentUserId();
        var cart = await _context.Carts
            .Include(c => c.CartProducts)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
        {
            cart = new Cart { UserId = userId };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }

        var cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.ProductId == productId);
        if (cartProduct == null)
        {
            cartProduct = new CartProduct { CartId = cart.CartId, ProductId = productId, Quantity = quantity };
            _context.CartProducts.Add(cartProduct);
        }
        else
        {
            cartProduct.Quantity += quantity;
        }

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(ProductsIndex));
    }

    private int GetCurrentUserId()
    {
        // Implement a method to retrieve the current user's ID
        return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }

}
