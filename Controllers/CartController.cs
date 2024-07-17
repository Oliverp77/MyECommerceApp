using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyECommerceApp.Data; // Replace with the actual namespace of your Data folder
using MyECommerceApp.Models; // Replace with the actual namespace of your Models folder
using System.Security.Claims;
using System.Threading.Tasks;

public class CartController : Controller
{
    private readonly ApplicationDbContext _context;

    public CartController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var userId = GetCurrentUserId(); // Implement this method to get the current user's ID
        var cart = await _context.Carts
            .Include(c => c.CartProducts)
                .ThenInclude(cp => cp.Product)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        return View(cart);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateQuantity(int cartId, int productId, int quantity)
    {
        var cartProduct = await _context.CartProducts
            .FirstOrDefaultAsync(cp => cp.CartId == cartId && cp.ProductId == productId);
        
        if (cartProduct != null)
        {
            cartProduct.Quantity = quantity;
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromCart(int cartId, int productId)
    {
        var cartProduct = await _context.CartProducts
            .FirstOrDefaultAsync(cp => cp.CartId == cartId && cp.ProductId == productId);
        
        if (cartProduct != null)
        {
            _context.CartProducts.Remove(cartProduct);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private int GetCurrentUserId()
    {
        // Implement a method to retrieve the current user's ID
        return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
