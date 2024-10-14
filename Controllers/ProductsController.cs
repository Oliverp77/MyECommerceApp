using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyECommerceApp.Data;
using MyECommerceApp.Models;
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

    [HttpPost]
    public async Task<IActionResult> AddToCart(int productId, int quantity)
    {
         if (!User.Identity.IsAuthenticated)
    {
        return RedirectToAction("Login", "Account");
    }

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
         var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
    }

}
